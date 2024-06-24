using BSG.EasyShop.Application.Contracts.Persistance;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductGroupTechSpec.Validators
{
    public class ProductGroupTechSpecCreateDTOValidator:AbstractValidator<ProductGroupTechSpecCreateDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupTechSpecCreateDTOValidator(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
                
            Include(new IProductGroupTechSpecDTOValidator(_productGroupRepository));
            
        }
    }
}
