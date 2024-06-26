using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Color.Validators
{
    public class ColorUpdateDTOValidator:AbstractValidator<ColorUpdateDTO>
    {
        public ColorUpdateDTOValidator()
        {
            Include(new IColorDTOValidator());

            RuleFor(x => x.Id)
                .NotNull().GreaterThan(0).WithMessage("{PropertyNam} is required.");                
            
        }
    }
}
