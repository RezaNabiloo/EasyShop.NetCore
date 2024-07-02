using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.DTOs.ProductGroup.Validators
{
    public class ProductGroupCreateDTOValidator:AbstractValidator<ProductGroupCreateDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupCreateDTOValidator(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;

            Include(new IProductGroupDTOValidator(_productGroupRepository));            
            
        }
    }
}
