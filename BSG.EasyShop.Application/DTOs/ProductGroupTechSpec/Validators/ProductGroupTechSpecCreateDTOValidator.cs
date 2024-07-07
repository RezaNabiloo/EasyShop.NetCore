using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductGroupTechSpec.Validators
{
    public class ProductGroupTechSpecCreateDTOValidator:AbstractValidator<ProductGroupTechSpecCreateDTO>
    {
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupTechSpecCreateDTOValidator(IProductGroupTechSpecRepository productGroupTechSpecRepository, IProductGroupRepository productGroupRepository)
        {
            _productGroupTechSpecRepository = productGroupTechSpecRepository;
            _productGroupRepository = productGroupRepository;
            Include(new IProductGroupTechSpecDTOValidator(_productGroupRepository));
            
        }
    }
}
