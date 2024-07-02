using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Languege.Validators
{
    public class LanguegeUpdateDTOValidator:AbstractValidator<LanguegeUpdateDTO>
    {
        public LanguegeUpdateDTOValidator()
        {
            Include(new ILanguegeDTOValidator());

            RuleFor(x => x.Id)
                .NotNull().GreaterThan(0).WithMessage("{PropertyNam} is required.");                
            
        }
    }
}
