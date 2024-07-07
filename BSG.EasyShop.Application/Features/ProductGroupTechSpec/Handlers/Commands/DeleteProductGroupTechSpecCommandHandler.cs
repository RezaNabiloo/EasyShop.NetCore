using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Handlers.Commands
{
    public class DeleteProductGroupTechSpecCommandHandler : IRequestHandler<DeleteProductGroupTechSpecCommand, CommandResponse<string>>
    {
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;
        private readonly IMapper _mapper;

        public DeleteProductGroupTechSpecCommandHandler(IProductGroupTechSpecRepository productGroupTechSpecRepository, IMapper mapper)
        {
            _productGroupTechSpecRepository = productGroupTechSpecRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteProductGroupTechSpecCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            var productGroup = await _productGroupTechSpecRepository.GetItemByKey(request.Id);
            #region Validation            
            if (productGroup == null)
            {
                response.Success = false;
                response.Message = "The deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not found." });
            }
            #endregion
            else {
                await _productGroupTechSpecRepository.Remove(productGroup);
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            
            return response;
        }
    }
}
