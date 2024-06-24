using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec.Validators;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductImage.Validators
{
    public class ProductGroupTechSpecUpdateDTOValidator : AbstractValidator<ProductGroupTechSpecUpdateDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupTechSpecUpdateDTOValidator(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;

            Include(new IProductGroupTechSpecDTOValidator(_productGroupRepository));
            RuleFor(x => x.Id).NotNull().WithMessage("{PrppertyName} is required.");
        }
    }
}
