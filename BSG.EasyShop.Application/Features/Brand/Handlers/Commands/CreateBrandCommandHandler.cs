using AutoMapper;
using BSG.EasyShop.Application.Contracts.Infrastructure.Email;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.Brand.Validators;
using BSG.EasyShop.Application.Features.Brand.Requests.Commands;
using BSG.EasyShop.Application.Models;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Handlers.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BaseCommandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, IEmailSender emailSender)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse { };
            #region Validation
            var validator = new BrandCreateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.BrandCreateDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion

            var data = _mapper.Map<Domain.Brand>(request.BrandCreateDTO);
            await _brandRepository.Add(data);

            response.Id = data.Id;
            response.Success = true;
            response.Message = "Creation Successful.";


            //var email = new Email
            //{
            //    To = "Customer@gmail.com",
            //    Subject = "Create Brand Submited.",
            //    Body = $"Brand creation successfully with id : {data.Id}" +
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
