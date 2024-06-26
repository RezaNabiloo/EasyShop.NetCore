using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Brand.Validators
{
    public class BrandUpdateDTOValidator:AbstractValidator<BrandUpdateDTO>
    {
        public BrandUpdateDTOValidator()
        {
            Include(new IBrandDTOValidator());

            RuleFor(x => x.Id)
                .NotNull().GreaterThan(0).WithMessage("{PropertyNam} is required.");                
            
        }
    }
}
