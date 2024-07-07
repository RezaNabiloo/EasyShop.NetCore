using BSG.EasyShop.Application.Contracts.Persistence.Common;
using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.DTOs.Common.Validators;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Brand.Validators
{
    public class BrandDeleteDTOValidator : AbstractValidator<BaseDTO>
    {
        private readonly IGenericRepository<Domain.Brand> _brandRepository;

        public BrandDeleteDTOValidator(IGenericRepository<Domain.Brand> brandRepository)
        {
            _brandRepository = brandRepository;
            Include(new BaseDTOExistValidator<BaseDTO,Domain.Brand>(_brandRepository));            
        }

    }
}
