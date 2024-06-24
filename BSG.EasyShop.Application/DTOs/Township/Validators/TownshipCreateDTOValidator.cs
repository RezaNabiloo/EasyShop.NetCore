using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Township.Validators
{
    public class TownshipCreateDTOValidator:AbstractValidator<TownshipCreateDTO>
    {
        private readonly IProvinceRepository _provinceRepository;
        
        public TownshipCreateDTOValidator(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
            
            
            Include(new ITownshipDTOValidator(_provinceRepository));
            
        }
    }
}
