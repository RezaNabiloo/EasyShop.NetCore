using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Country.Validators;
using BSG.EasyShop.Application.Features.Country.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Handlers.Commands
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, BaseCommandResponse>
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly IMapper _mapper;

        public UpdateCountryCommandHandler(ICountryRepository CountryRepository, IMapper mapper)
        {
            _CountryRepository = CountryRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation
            var validator = new CountryUpdateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CountryUpdateDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            #endregion

            var Country = await _CountryRepository.GetItemByKey(request.Id);
            _mapper.Map(request.CountryUpdateDTO, Country);
            await _CountryRepository.Update(Country);

            
            response.Success = true;
            response.Message = "Update Successful.";
            return response; 
        }
    }
}
