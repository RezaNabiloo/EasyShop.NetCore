using BSG.EasyShop.Application.Contracts.Persistance;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductImage.Validators
{
    public class IProductImageDTOValidator:AbstractValidator<IProductImageDTO>
    {
        private readonly IProductRepository _productRepository;

        public IProductImageDTOValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;


            RuleFor(x => x.ProductId).MustAsync(async (id, token) =>
            {
                var exist = await _productRepository.Exist(id);
                return !exist;
            }).WithMessage("{PropertyName} not exist.");
            
        }
    }
}
