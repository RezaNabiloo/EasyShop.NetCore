using BSG.EasyShop.Application.Contracts.Persistence.Common;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Common.Validators
{
    //public class BaseDTOValidator<T> : AbstractValidator<long> where T : class
    //{
    //    private readonly IGenericRepository<T> _repository;

    //    public BaseDTOValidator(IGenericRepository<T> repository)
    //    {
    //        _repository = repository;
    //        RuleFor(id => id)
    //       .NotNull().GreaterThan(0).WithMessage("{PropertyName} is required.")
    //       .MustAsync(async (id, cancellation) => await _repository.Exist(id) /*&& id>0*/)
    //       .WithMessage("The item with Id {PropertyValue} does not exist.");

    //    }
    //}
    public class BaseDTOExistValidator<TDTO, T> : AbstractValidator<TDTO> where TDTO : BaseDTO where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public BaseDTOExistValidator(IGenericRepository<T> repository)
        {
            _repository = repository;
            RuleFor(x => x.Id)
           .NotNull().GreaterThan(0).WithMessage("{PropertyName} is required.")
           .MustAsync(async (id, cancellation) => await _repository.Exist(id) /*&& id>0*/)
           .WithMessage("The item with Id {PropertyValue} does not exist.");

        }
    }
}
