using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductImage.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductImage.Requests.Commands;
using BSG.EasyShop.Application.Responses;
using BSG.EasyShop.Domain;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace BSG.EasyShop.Application.Features.ProductImage.Handlers.Commands
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;        
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateProductImageCommandHandler(IProductRepository productRepository, IProductImageRepository productImageRepository, IBrandRepository brandRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            #region Validation
            var validator = new ProductImageCreateDTOValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(request.ProductImageCreateDTO);

            if (validationResult.IsValid == true)
            {
                var productImage = _mapper.Map<Domain.ProductImage>(request.ProductImageCreateDTO);
                productImage = await _productImageRepository.Add(productImage);

                response.Message = "Creation is successful.";
                response.Id = productImage.Id;
                response.Success = true;
            }
            #endregion
            else {

                response.Message = "Creation failed.";                
                response.Success = false;
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            
            return response;
        }
    }
}
