using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductTechSpec.Validators
{
    public class ProductTechSpecCreateDTOValidator:AbstractValidator<ProductTechSpecCreateDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;

        public ProductTechSpecCreateDTOValidator(IProductRepository productRepository, IProductGroupTechSpecRepository productGroupTechSpecRepository)
        {
            _productRepository = productRepository;
            _productGroupTechSpecRepository = productGroupTechSpecRepository;

            Include(new IProductTechSpecDTOValidator(_productRepository, _productGroupTechSpecRepository));
            
        }
    }
}
