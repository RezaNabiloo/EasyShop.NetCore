using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.DTOs.ProductGroup.Validators
{
    public class ProductGroupUpdateDTOValidator:AbstractValidator<ProductGroupUpdateDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupUpdateDTOValidator(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;

            Include(new IProductGroupDTOValidator(_productGroupRepository));

            RuleFor(x=>x.Id).NotNull().WithMessage("{PropertyName} is required.");
            
        }
    }
}
