using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Brand.Validators
{
    public class IBrandDTOValidator:AbstractValidator<IBrandDTO>
    {
        public IBrandDTOValidator()
        {
            RuleFor(x => x.FaTitle)
                .NotNull().NotEmpty().WithMessage("{PropertyNam is required.}")
                .MaximumLength(50).WithMessage("{PropertyNam} ength is more than 50.}");

            RuleFor(x => x.EnTitle)
                .MaximumLength(50).WithMessage("{PropertyNam} ength is more than 50.}");
        }
    }
}
