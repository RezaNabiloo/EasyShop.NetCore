using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Common.Validatotrs;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace BSG.EasyShop.Application.DTOs.Color.Validators
{
    public class ColorUpdateDTOValidator : AbstractValidator<ColorUpdateDTO>
    {
        private readonly IColorRepository _colorRepository;

        public ColorUpdateDTOValidator(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
            Include(new IColorExistValidator(colorRepository));
            Include(new IColorDTOValidator());

            RuleFor(x => x.Id)
                .NotNull().GreaterThan(0).WithMessage("{PropertyNam} is required.");

        }
    }
}
