using AutoMapper;
using BSG.EasyShop.Application.Contracts.Infrastructure.Email;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Country.Validators;
using BSG.EasyShop.Application.Features.Country.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Handlers.Commands
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, BaseCommandResponse>
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateCountryCommandHandler(ICountryRepository CountryRepository, IMapper mapper, IEmailSender emailSender)
        {
            _CountryRepository = CountryRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse { };
            #region Validation
            var validator = new CountryCreateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CountryCreateDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion

            var data = _mapper.Map<Domain.Country>(request.CountryCreateDTO);
            await _CountryRepository.Add(data);

            response.Id = data.Id;
            response.Success = true;
            response.Message = "Creation Successful.";


            //var email = new Email
            //{
            //    To = "Customer@gmail.com",
            //    Subject = "Create Country Submited.",
            //    Body = $"Country creation successfully with id : {data.Id}" +
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
