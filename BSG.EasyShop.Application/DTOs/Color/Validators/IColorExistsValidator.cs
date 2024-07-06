using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Common;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Color.Validators
{
    public class IColorExistValidator : AbstractValidator<BaseDTO>
    {
        private readonly IColorRepository _colorRepository;

        public IColorExistValidator(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;

            RuleFor(x => x.Id).MustAsync(async (id, token) =>
            {
                var exist = await _colorRepository.Exist(id);
                return exist && id > 0;
            }).WithMessage("Item dose not exist.");

        }

    }
}

