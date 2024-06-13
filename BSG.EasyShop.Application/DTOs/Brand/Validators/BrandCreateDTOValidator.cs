using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Brand.Validators
{
    public class BrandCreateDTOValidator:AbstractValidator<BrandCreateDTO>
    {
        public BrandCreateDTOValidator()
        {

            Include(new IBrandDTOValidator());
            
        }
    }
}
