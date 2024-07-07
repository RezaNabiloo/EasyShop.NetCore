using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using BSG.EasyShop.Application.DTOs.ProductTechSpec.Validators;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductTechSpec.Validators
{
    public class ProductTechSpecUpdateDTOValidator : AbstractValidator<ProductTechSpecUpdateDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;

        public ProductTechSpecUpdateDTOValidator(IProductRepository productRepository, IProductGroupTechSpecRepository productGroupTechSpecRepository)
        {
            _productRepository = productRepository;
            _productGroupTechSpecRepository = productGroupTechSpecRepository;

            Include(new IProductTechSpecDTOValidator(_productRepository, _productGroupTechSpecRepository));
            RuleFor(x => x.Id).NotNull().WithMessage("{PrppertyName} is required.");
        }
    }
}
