using BSG.EasyShop.Application.Contracts.Persistance;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Product.Validators
{
    public class IProductDTOValidator : AbstractValidator<IProductDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IBrandRepository _brandRepository;

        public IProductDTOValidator(IProductGroupRepository productGroupRepository, IBrandRepository brandRepository)
        {
            _productGroupRepository = productGroupRepository;
            _brandRepository = brandRepository;


            RuleFor(x => x.Title)
               .NotNull().NotEmpty().WithMessage("{PropertyNam is required.}")
               .MaximumLength(50).WithMessage("{PropertyNam} ength is more than 50.}");

            RuleFor(x => x.ProductGroupId).NotNull().WithMessage("{PropertyNam} ength is more than 50.}")
                .MustAsync(async (id, token) =>
                {
                    var exist = await _productGroupRepository.Exist(id);
                    return !exist;
                }).WithMessage("{PropertyName} dose not exists.");

            RuleFor(x => x.BrandId).MustAsync(async (id, token) =>
                {
                    var exist = await _brandRepository.Exist(id ?? 0);
                    return !exist && (id > 0) ;
                }).WithMessage("{PropertyName} dose not exists.");

        }
    }
}
