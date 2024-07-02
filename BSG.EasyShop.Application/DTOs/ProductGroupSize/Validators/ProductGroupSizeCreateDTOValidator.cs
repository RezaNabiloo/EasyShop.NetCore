using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductImage.Validators;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductImage.Validators
{
    public class ProductGroupSizeCreateDTOValidator:AbstractValidator<ProductImageCreateDTO>
    {
        private readonly IProductRepository _productRepository;

        public ProductGroupSizeCreateDTOValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
                
            Include(new IProductImageDTOValidator(_productRepository));
            
        }
    }
}
