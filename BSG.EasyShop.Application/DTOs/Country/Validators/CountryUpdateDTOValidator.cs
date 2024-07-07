using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Country.Validators
{
    public class CountryUpdateDTOValidator:AbstractValidator<CountryUpdateDTO>
    {
        public CountryUpdateDTOValidator()
        {
            Include(new ICountryDTOValidator());

            RuleFor(x => x.Id)
                .NotNull().GreaterThan(0).WithMessage("{PropertyNam} is required.");                
            
        }
    }
}
