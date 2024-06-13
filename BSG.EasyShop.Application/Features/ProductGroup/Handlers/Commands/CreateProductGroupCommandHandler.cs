using AutoMapper;
using BSG.EasyShop.Application.DTOs.ProductGroup.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistance;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Handlers.Commands
{
    public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, long>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public CreateProductGroupCommandHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new ProductGroupCreateDTOValidator(_productGroupRepository);
            var validationResult = await validator.ValidateAsync(request.ProductGroupCreateDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion


            var data = _mapper.Map<Domain.ProductGroup>(request.ProductGroupCreateDTO);
            data = await _productGroupRepository.Add(data);
            return data.Id;

        }
    }
}
