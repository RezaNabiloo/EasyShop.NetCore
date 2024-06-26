using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Color.Validators
{
    public class ColorCreateDTOValidator:AbstractValidator<ColorCreateDTO>
    {
        public ColorCreateDTOValidator()
        {

            Include(new IColorDTOValidator());
            
        }
    }
}
