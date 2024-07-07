using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductTechSpec.Validators;
using BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using FluentValidation;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductTechSpec.Handlers.Commands
{
    public class UpdateProductTechSpecCommandHandler : IRequestHandler<UpdateProductTechSpecCommand, CommandResponse<string>>
    {
        private readonly IProductTechSpecRepository _productTechSpecRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;
        private readonly IMapper _mapper;

        public UpdateProductTechSpecCommandHandler(IProductTechSpecRepository productTechSpecRepository, IProductRepository productRepository, IProductGroupTechSpecRepository productGroupTechSpecRepository, IMapper mapper)
        {
            _productTechSpecRepository = productTechSpecRepository;
            _productRepository = productRepository;
            _productGroupTechSpecRepository = productGroupTechSpecRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<string>> Handle(UpdateProductTechSpecCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            #region Validation
            var validator = new ProductTechSpecUpdateDTOValidator(_productRepository, _productGroupTechSpecRepository);
            var validationResult = await validator.ValidateAsync(request.ProductTechSpecUpdateDTO);            
            if (validationResult.IsValid == false)            {
                response.Success = false;
                response.Message = "Editing was failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var product = await _productTechSpecRepository.GetItemByKey(request.Id);
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "The deletion was failed.";
                    response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
                }
                else
                {
                    product = _mapper.Map<Domain.ProductTechSpec>(request.Id);
                    await _productTechSpecRepository.Update(product);
                    response.Success = true;
                    response.Message = "Editing was done successfully.";
                }
            }
            return response;
            //return Unit.Value;  
        }
    }
}
