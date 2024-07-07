using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Color.Validators
{
    public class ColorUpdateDTOValidator : AbstractValidator<ColorUpdateDTO>
    {
        private readonly IColorRepository _colorRepository;

        public ColorUpdateDTOValidator(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;            
            Include(new IColorDTOValidator());
            RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage("{PropertyNam} is required.");
        }
        //private readonly IGenericRepository<Domain.Color> _colorRepository;

        //public ColorUpdateDTOValidator(IGenericRepository<Domain.Color> colorRepository)
        //{
        //    _colorRepository = colorRepository;
        //    Include(new BaseDTOExistValidator<ColorUpdateDTO, Domain.Color>(_colorRepository));            
        //    Include(new IColorDTOValidator());            
        //}

    }
}
