using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Languege.Validators
{
    public class LanguegeCreateDTOValidator:AbstractValidator<LanguegeCreateDTO>
    {
        public LanguegeCreateDTOValidator()
        {

            Include(new ILanguegeDTOValidator());
            
        }
    }
}
