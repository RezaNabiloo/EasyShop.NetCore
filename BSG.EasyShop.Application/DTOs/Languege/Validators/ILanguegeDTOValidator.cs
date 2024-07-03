using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Languege.Validators
{
    public class ILanguegeDTOValidator:AbstractValidator<ILanguegeDTO>
    {
        public ILanguegeDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyNam} Length is more than 50.");

            RuleFor(x => x.Abbreviation)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(2).WithMessage("{PropertyNam} Length is should be 2.");

        }
    }
}
