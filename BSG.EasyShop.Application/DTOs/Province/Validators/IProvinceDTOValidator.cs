using BSG.EasyShop.Application.Contracts.Persistence;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Province.Validators
{
    public class IProvinceDTOValidator : AbstractValidator<IProvinceDTO>
    {
        private readonly ICountryRepository _countryRepository;
        

        public IProvinceDTOValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;            


            RuleFor(x => x.Title)
               .NotNull().NotEmpty().WithMessage("{PropertyNam} is required.")
               .MaximumLength(50).WithMessage("{PropertyNam} length is more than 50.}");

            RuleFor(x => x.CountryId).NotNull().WithMessage("{PropertyNam}  is required.")
                .MustAsync(async (id, token) =>
                {
                    var exist = await countryRepository.Exist(id);
                    return !exist;
                }).WithMessage("{PropertyName} dose not exists.");

        }
    }
}
