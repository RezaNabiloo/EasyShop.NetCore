using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Contracts.Persistence.Common;
using FluentValidation;

namespace BSG.EasyShop.Application.DTOs.Common.Validators
{
    public class IExistValidator<TDTO, TEntity>:AbstractValidator<TDTO>
        where TDTO : BaseDTO
        where TEntity: class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public IExistValidator(IGenericRepository<TEntity> repository)
        {
            _repository = repository;

            RuleFor(x => x.Id).MustAsync(async (id, token) =>
            {
                var exist = await _repository.Exist(id);
                return exist && id > 0;
            }).WithMessage("Item does not exist.");
        }
    }
}
