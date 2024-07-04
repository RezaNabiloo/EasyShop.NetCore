using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductImage.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductImage.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain;
using BSG.EasyShop.Domain.Enum;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace BSG.EasyShop.Application.Features.ProductImage.Handlers.Commands
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, CommandResponse<long>>
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
        public async Task<CommandResponse<long>> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<long>();
            #region Validation
            var validator = new ProductImageCreateDTOValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(request.ProductImageCreateDTO);

            if (validationResult.IsValid == false)
            {
                response.Message = "Creation failed.";
                response.Success = false;
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else {
                var productImage = _mapper.Map<Domain.ProductImage>(request.ProductImageCreateDTO);
                productImage = await _productImageRepository.Add(productImage);

                response.Message = "Creation is successful.";
                response.Result = productImage.Id;
                response.Success = true;
            }
            
            return response;
        }
    }
}
