using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Township.Validators
{
    public class ITownshipDTOValidator : AbstractValidator<ITownshipDTO>
    {
        private readonly IProvinceRepository _provinceRepository;
        

        public ITownshipDTOValidator(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;            


            RuleFor(x => x.Title)
               .NotNull().NotEmpty().WithMessage("{PropertyNam} is required.")
               .MaximumLength(50).WithMessage("{PropertyNam} length is more than 50.}");

            RuleFor(x => x.ProvinceId).NotNull().WithMessage("{PropertyNam}  is required.")
                .MustAsync(async (id, token) =>
                {
                    var exist = await provinceRepository.Exist(id);
                    return !exist;
                }).WithMessage("{PropertyName} dose not exists.");

            RuleFor(x => x.Lat).NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithMessage("{PropertyName} can not be negative.");
            RuleFor(x => x.Lng).NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithMessage("{PropertyName} can not be negative.");

        }
    }
}
