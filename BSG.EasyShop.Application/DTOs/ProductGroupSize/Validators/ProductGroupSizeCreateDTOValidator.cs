using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductGroup;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductGroupSize.Validators
{
    public class ProductGroupSizeCreateDTOValidator:AbstractValidator<ProductGroupSizeCreateDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupSizeCreateDTOValidator(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
                
            Include(new IProductGroupSizeDTOValidator(_productGroupRepository));
            
        }
    }
}
