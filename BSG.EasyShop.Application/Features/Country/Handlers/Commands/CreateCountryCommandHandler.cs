using AutoMapper;
using BSG.EasyShop.Application.Contracts.Infrastructure.Email;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Country.Validators;
using BSG.EasyShop.Application.Features.Country.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Handlers.Commands
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CommandResponse<long>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper, IEmailSender emailSender)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<CommandResponse<long>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new CountryCreateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CountryCreateDTO);
            #endregion

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            else
            {

                var data = _mapper.Map<Domain.Country>(request.CountryCreateDTO);
                await _countryRepository.Add(data);
                response.Result = data.Id;
                response.Success = true;
                response.Message = "Creation Successful.";
            }

            return response;
        }
    }
}
