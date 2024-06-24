﻿using BSG.EasyShop.Application.Contracts.Persistance;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.ProductGroupSize.Validators
{
    public class IProductGroupSizeDTOValidator:AbstractValidator<IProductGroupSizeDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public IProductGroupSizeDTOValidator(IProductGroupRepository productGroupRepository)
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
