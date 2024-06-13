using AutoMapper;
using BSG.EasyShop.Application.DTOs.Product.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Product.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistance;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IProductGroupRepository productGroupRepository, IBrandRepository brandRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new ProductCreateDTOValidator(_productGroupRepository, _brandRepository);
            var validationResult = await validator.ValidateAsync(request.ProductCreateDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            #endregion

            var data = _mapper.Map<Domain.Product>(request.ProductCreateDTO);

            data = await _productRepository.Add(data);
            return data.Id;
        }
    }
}
