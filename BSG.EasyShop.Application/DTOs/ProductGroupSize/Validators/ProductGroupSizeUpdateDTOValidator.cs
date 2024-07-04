using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductGroupSize;
using BSG.EasyShop.Application.DTOs.ProductGroupSize.Validators;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductImage.Validators
{
    public class ProductGroupSizeUpdateDTOValidator : AbstractValidator<ProductGroupSizeUpdateDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupSizeUpdateDTOValidator(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;

            Include(new IProductGroupSizeDTOValidator(_productGroupRepository));
            RuleFor(x => x.Id).NotNull().WithMessage("{PrpertyName} is required.");
        }
    }
}
