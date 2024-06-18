using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Brand.Validators
{
    public class IBrandDTOValidator:AbstractValidator<IBrandDTO>
    {
        public IBrandDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty().WithMessage("{Title is required.}")
                .MaximumLength(50).WithMessage("{PropertyNam} ength is more than 50.}");

        }
    }
}
