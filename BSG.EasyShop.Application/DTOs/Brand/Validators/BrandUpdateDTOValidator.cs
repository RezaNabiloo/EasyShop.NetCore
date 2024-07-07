using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Brand.Validators
{
    public class BrandUpdateDTOValidator:AbstractValidator<BrandUpdateDTO>
    {
        private readonly IBrandRepository _brandRepository;

        public BrandUpdateDTOValidator(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;            
            Include(new IBrandDTOValidator());
            RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage("{PropertyNam is required.}");
        }


        //private readonly IGenericRepository<Domain.Brand> _brandRepository;

        //public BrandUpdateDTOValidator(IGenericRepository<Domain.Brand> brandRepository)
        //{
        //    _brandRepository = brandRepository;
        //    Include(new BaseDTOExistValidator<BrandUpdateDTO, Domain.Brand>(_brandRepository));
        //    Include(new IBrandDTOValidator());                      
        //}
    }
}
