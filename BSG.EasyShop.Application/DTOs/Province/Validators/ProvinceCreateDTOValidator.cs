using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Province;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Province.Validators
{
    public class ProvinceCreateDTOValidator:AbstractValidator<ProvinceCreateDTO>
    {
        private readonly ICountryRepository _countryRepository;
        
        public ProvinceCreateDTOValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            
            
            Include(new IProvinceDTOValidator(_countryRepository));
            
        }
    }
}
