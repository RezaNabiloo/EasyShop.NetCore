using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.ProductImage.Validators;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductImage.Validators
{
    public class ProductImageCreateDTOValidator:AbstractValidator<ProductImageCreateDTO>
    {
        private readonly IProductRepository _productRepository;

        public ProductImageCreateDTOValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
                
            Include(new IProductImageDTOValidator(_productRepository));
            
        }
    }
}
