using AutoMapper;
using BSG.EasyShop.Application.DTOs.Product.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Product.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistance;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IProductGroupRepository productGroupRepository, IBrandRepository brandRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetItemByKey(request.Id);

            // Update Product
            if (request.ProductUpdateDTO != null)
            {
                #region Validation
                var validator = new ProductUpdateDTOValidator(_productGroupRepository, _brandRepository);
                var validationResult = await validator.ValidateAsync(request.ProductUpdateDTO);

                if (validationResult.IsValid == false)
                {
                    throw new ValidationException(validationResult);
                }
                #endregion

                _mapper.Map(request.ProductUpdateDTO, data);
                await _productRepository.Update(data);
            }
            // Confirm Product
            else if (request.ProductConfirmDTO != null)
            {
                #region Validation
                var validator = new ProductConfirmDTOValidator(_productRepository);
                var validationResult = await validator.ValidateAsync(request.ProductConfirmDTO);

                if (validationResult.IsValid == false)
                {
                    throw new ValidationException(validationResult);
                }
                #endregion
                await _productRepository.Confirm(data, request.ProductConfirmDTO.IsConfirmed);
            }
            return Unit.Value;

        }
    }
}
