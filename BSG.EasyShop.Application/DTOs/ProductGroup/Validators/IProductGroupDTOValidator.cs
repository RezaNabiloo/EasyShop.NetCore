using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.DTOs.ProductGroup.Validators
{
    public class IProductGroupDTOValidator : AbstractValidator<IProductGroupDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public IProductGroupDTOValidator(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;

            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.ParentProductGroupId).MustAsync(async (id, token) =>
            {
                var exist = await _productGroupRepository.Exist(id ?? 0);
                return !exist && id > 0;
            }).WithMessage("{PropertyName} not exist.");

        }
    }
}
