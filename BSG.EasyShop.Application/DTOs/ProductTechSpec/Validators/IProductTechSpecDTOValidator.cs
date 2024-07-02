using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductTechSpec.Validators
{
    public class IProductTechSpecDTOValidator:AbstractValidator<IProductTechSpecDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;

        public IProductTechSpecDTOValidator(IProductRepository productRepository, IProductGroupTechSpecRepository productGroupTechSpecRepository)
        {
            _productRepository = productRepository;
            _productGroupTechSpecRepository = productGroupTechSpecRepository;

            RuleFor(x => x.ProductId).MustAsync(async (id, token) =>
            {
                var exist = await _productRepository.Exist(id);
                return !exist;
            }).WithMessage("{PropertyName} not exist.");

            RuleFor(x => x.ProductGroupTechSpecId).MustAsync(async (id, token) =>
            {
                var exist = await _productGroupTechSpecRepository.Exist(id);
                return !exist;
            }).WithMessage("{PropertyName} not exist.");
        }
    }
}
