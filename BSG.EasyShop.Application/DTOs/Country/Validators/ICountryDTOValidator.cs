using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Country.Validators
{
    public class ICountryDTOValidator:AbstractValidator<ICountryDTO>
    {
        public ICountryDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage("{Title is required.}")
                .MaximumLength(50).WithMessage("{PropertyNam} Length is more than 50.}");

        }
    }
}
