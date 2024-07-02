using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Product.Validators
{
    public class ProductCreateDTOValidator:AbstractValidator<ProductCreateDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductCreateDTOValidator(IProductGroupRepository productGroupRepository, IBrandRepository brandRepository)
        {
            _productGroupRepository = productGroupRepository;
            _brandRepository = brandRepository;
            
            Include(new IProductDTOValidator(_productGroupRepository, _brandRepository));
            
        }
    }
}
