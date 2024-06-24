using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Province.Validators
{
    public class ProvinceUpdateDTOValidator:AbstractValidator<ProvinceUpdateDTO>
    {
        private readonly ICountryRepository _countryRepository;
        
        public ProvinceUpdateDTOValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;            
            
            Include(new IProvinceDTOValidator(countryRepository));

            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required.");
            
        }
    }
}
