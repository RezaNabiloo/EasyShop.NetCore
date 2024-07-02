using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Product.Validators
{
    public class ProductUpdateDTOValidator:AbstractValidator<ProductUpdateDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductUpdateDTOValidator(IProductGroupRepository productGroupRepository, IBrandRepository brandRepository)
        {
            _productGroupRepository = productGroupRepository;
            _brandRepository = brandRepository;
            
            Include(new IProductDTOValidator(_productGroupRepository, _brandRepository));

            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required.");
            
        }
    }
}
