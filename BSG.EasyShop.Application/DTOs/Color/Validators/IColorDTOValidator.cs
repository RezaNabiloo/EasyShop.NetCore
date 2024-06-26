using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Color.Validators
{
    public class IColorDTOValidator : AbstractValidator<IColorDTO>
    {
        public IColorDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyNam} Length is more than 50.}");

            RuleFor(x => x.ColorCode)
                            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
                            .MaximumLength(7).WithMessage("{PropertyNam} Length is more than 7.}");

            RuleFor(x => x.ColorCode)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .Matches(@"^#(?:[0-9a-fA-F]{3}){1,2}$")
           .WithMessage("Invalid color code format. Expected format: #RRGGBB or #RGB");
        }

    }
}

