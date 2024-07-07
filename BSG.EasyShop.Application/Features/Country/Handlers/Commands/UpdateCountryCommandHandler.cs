using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Country.Validators;
using BSG.EasyShop.Application.Features.Country.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using BSG.EasyShop.Domain;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Handlers.Commands
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, CommandResponse<string>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public UpdateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<string>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();

            #region Validation
            var validator = new CountryUpdateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CountryUpdateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Editing was failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {

                var country = await _countryRepository.GetItemByKey(request.Id);
                if (country == null)
                {
                    response.Success = false;
                    response.Message = "The deletion was failed.";
                    response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
                }
                else
                {
                    _mapper.Map(request.CountryUpdateDTO, country);
                    await _countryRepository.Update(country);
                    response.Success = true;
                    response.Message = "Editing was done successfully.";
                }
            }
            return response;
        }
    }
}
