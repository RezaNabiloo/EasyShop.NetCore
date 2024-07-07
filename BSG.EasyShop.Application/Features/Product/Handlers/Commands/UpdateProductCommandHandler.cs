using AutoMapper;
using BSG.EasyShop.Application.DTOs.Product.Validators;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Product.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Features.Product.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CommandResponse<string>>
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
        public async Task<CommandResponse<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            var product = await _productRepository.GetItemByKey(request.Id);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Editing was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
            }
            else if (request.ProductUpdateDTO != null)
            {
                #region Validation
                var validator = new ProductUpdateDTOValidator(_productGroupRepository, _brandRepository);
                var validationResult = await validator.ValidateAsync(request.ProductUpdateDTO);

                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Editing was failed.";
                    response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
                }
                #endregion
                else
                {
                    _mapper.Map(request.ProductUpdateDTO, product);
                    await _productRepository.Update(product);
                    response.Success = true;
                    response.Message = "Editing was done successfully.";

                }

            }
            // Confirm Product
            else if (request.ProductConfirmDTO != null)
            {
                #region Validation
                var validator = new ProductConfirmDTOValidator(_productRepository);
                var validationResult = await validator.ValidateAsync(request.ProductConfirmDTO);

                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Editing was failed.";
                    response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
                }
                #endregion
                else
                {
                    await _productRepository.Confirm(product, request.ProductConfirmDTO.IsConfirmed);
                    response.Success = true;
                    response.Message = "Confirming was done Successfully.";
                }

            }
            return response;

        }
    }
}
