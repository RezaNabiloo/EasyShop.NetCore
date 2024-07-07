using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductImage.Validators;
using BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Handlers.Commands
{
    public class UpdateProductGroupTechSpecCommandHandler : IRequestHandler<UpdateProductGroupTechSpecCommand, CommandResponse<string>>
    {
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public UpdateProductGroupTechSpecCommandHandler(IProductGroupTechSpecRepository productGroupTechSpecRepository, IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupTechSpecRepository = productGroupTechSpecRepository;
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponse<string>> Handle(UpdateProductGroupTechSpecCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            #region Validation
            var validator = new ProductGroupTechSpecUpdateDTOValidator(_productGroupRepository);
            var validationResult = await validator.ValidateAsync(request.ProductGroupTechSpecUpdateDTO);            
            if (validationResult.IsValid == false)            {
                response.Success = false;
                response.Message = "Editing was failed.";
                response.ResultMessages = validationResult.Errors.Select(x => new ResultMessage { MessageType = Domain.Enum.ResultMessageType.Validation, Message = x.ErrorMessage }).ToList();
            }
            #endregion
            else
            {
                var productGroup = await _productGroupTechSpecRepository.GetItemByKey(request.ProductGroupTechSpecUpdateDTO.Id);
                if (productGroup == null)
                {
                    response.Success = false;
                    response.Message = "The deletion was failed.";
                    response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
                }
                else
                {
                    productGroup = _mapper.Map<Domain.ProductGroupTechSpec>(request.ProductGroupTechSpecUpdateDTO);
                    await _productGroupTechSpecRepository.Update(productGroup);
                    response.Success = true;
                    response.Message = "Editing was done successfully.";
                }
            }
            return response;
            //return Unit.Value;  
        }
    }
}
