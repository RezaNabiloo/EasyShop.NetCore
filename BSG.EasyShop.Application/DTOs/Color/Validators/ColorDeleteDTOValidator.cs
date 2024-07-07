using BSG.EasyShop.Application.Contracts.Persistence.Common;
using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.DTOs.Common.Validators;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Color.Validators
{
    public class ColorDeleteDTOValidator : AbstractValidator<BaseDTO>
    {
        private readonly IGenericRepository<Domain.Color> _colorRepository;

        public ColorDeleteDTOValidator(IGenericRepository<Domain.Color> colorRepository)
        {
            _colorRepository = colorRepository;
            Include(new BaseDTOExistValidator<BaseDTO, Domain.Color>(_colorRepository));
        }

    }
}
