using AutoMapper;
using BSG.EasyShop.Application.Contracts.Infrastructure.Email;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Township.Validators;
using BSG.EasyShop.Application.Features.Township.Requests.Commands;
using BSG.EasyShop.Application.Models;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Handlers.Commands
{
    public class CreateTownshipCommandHandler : IRequestHandler<CreateTownshipCommand, BaseCommandResponse>
    {
        private readonly ITownshipRepository _townshipRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateTownshipCommandHandler(ITownshipRepository TownshipRepository, IProvinceRepository provinceRepository, IMapper mapper, IEmailSender emailSender)
        {
            _townshipRepository = TownshipRepository;
            _provinceRepository = provinceRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateTownshipCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse { };
            #region Validation
            var validator = new TownshipCreateDTOValidator(_provinceRepository);
            var validationResult = await validator.ValidateAsync(request.TownshipCreateDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion

            var data = _mapper.Map<Domain.Township>(request.TownshipCreateDTO);
            await _townshipRepository.Add(data);

            response.Id = data.Id;
            response.Success = true;
            response.Message = "Creation Successful.";


            //var email = new Email
            //{
            //    To = "Customer@gmail.com",
            //    Subject = "Create Township Submited.",
            //    Body = $"Township creation successfully with id : {data.Id}" +
            //            $"you can see this in database"
            //};

            //try
            //{
            //    await _emailSender.SendEmail(email);
            //}
            //catch (Exception)
            //{
            //    // TOD O
            //    // log error
            //}
            return response;
        }
    }
}
