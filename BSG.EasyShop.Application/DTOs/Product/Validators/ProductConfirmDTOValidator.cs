using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Product.Validators
{
    public class ProductConfirmDTOValidator : AbstractValidator<ProductConfirmDTO>
    {
        private readonly IProductRepository _productRepository;

        public ProductConfirmDTOValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;


            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyNam} is required.");
                //.MustAsync(async (id, token) =>
                //{
                //    var exist = await _productRepository.Exist(id);
                //    return !exist;
                //}
                //).WithMessage("Item dose not exists");
            RuleFor(x => x.IsConfirmed).NotNull().WithMessage("{PropertyNam} is required.");
        }
    }
}
