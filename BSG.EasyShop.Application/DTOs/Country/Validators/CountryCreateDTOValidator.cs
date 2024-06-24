using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Country.Validators
{
    public class CountryCreateDTOValidator:AbstractValidator<CountryCreateDTO>
    {
        public CountryCreateDTOValidator()
        {

            Include(new ICountryDTOValidator());
            
        }
    }
}
