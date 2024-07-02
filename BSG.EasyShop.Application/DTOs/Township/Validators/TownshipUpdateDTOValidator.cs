using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Township.Validators
{
    public class TownshipUpdateDTOValidator:AbstractValidator<TownshipUpdateDTO>
    {
        private readonly IProvinceRepository _provinceRepository;
        
        public TownshipUpdateDTOValidator(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;            
            
            Include(new ITownshipDTOValidator(_provinceRepository));

            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required.");
            
        }
    }
}
