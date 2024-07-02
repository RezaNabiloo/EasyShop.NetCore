using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductGroupTechSpec.Validators
{
    public class IProductGroupTechSpecDTOValidator:AbstractValidator<IProductGroupTechSpecDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public IProductGroupTechSpecDTOValidator(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;


            RuleFor(x => x.ProductGroupId).MustAsync(async (id, token) =>
            {
                var exist = await _productGroupRepository.Exist(id);
                return !exist;
            }).WithMessage("{PropertyName} not exist.");
            
        }
    }
}
