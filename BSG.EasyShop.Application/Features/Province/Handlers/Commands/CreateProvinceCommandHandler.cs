using AutoMapper;
using BSG.EasyShop.Application.Contracts.Infrastructure.Email;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Province.Validators;
using BSG.EasyShop.Application.Features.Province.Requests.Commands;
using BSG.EasyShop.Application.Models;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Handlers.Commands
{
    public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, BaseCommandResponse>
    {
        private readonly IProvinceRepository _ProvinceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateProvinceCommandHandler(IProvinceRepository ProvinceRepository, ICountryRepository countryRepository, IMapper mapper, IEmailSender emailSender)
        {
            _ProvinceRepository = ProvinceRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse { };
            #region Validation
            var validator = new ProvinceCreateDTOValidator(_countryRepository);
            var validationResult = await validator.ValidateAsync(request.ProvinceCreateDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion

            var data = _mapper.Map<Domain.Province>(request.ProvinceCreateDTO);
            await _ProvinceRepository.Add(data);

            response.Id = data.Id;
            response.Success = true;
            response.Message = "Creation Successful.";


            //var email = new Email
            //{
            //    To = "Customer@gmail.com",
            //    Subject = "Create Province Submited.",
            //    Body = $"Province creation successfully with id : {data.Id}" +
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
