using AutoMapper;
using BSG.EasyShop.Application.DTOs.ProductGroup.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Handlers.Commands
{
    public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, Unit>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public UpdateProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductGroupCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new ProductGroupUpdateDTOValidator(_productGroupRepository);
            var validationResult = await validator.ValidateAsync(request.ProductGroupUpdateDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion


            var data = await _productGroupRepository.GetItemByKey(request.ProductGroupUpdateDTO.Id);
            data = _mapper.Map<Domain.ProductGroup>(request.ProductGroupUpdateDTO);
            await _productGroupRepository.Update(data);
            return Unit.Value;  
        }
    }
}
