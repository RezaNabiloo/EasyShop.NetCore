using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductTechSpec.Handlers.Commands
{
    public class DeleteProductTechSpecCommandHandler : IRequestHandler<DeleteProductTechSpecCommand, CommandResponse<string>>
    {
        private readonly IProductTechSpecRepository _productTechSpecRepository;
        private readonly IMapper _mapper;

        public DeleteProductTechSpecCommandHandler(IProductTechSpecRepository productTechSpecRepository, IMapper mapper)
        {
            _productTechSpecRepository = productTechSpecRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteProductTechSpecCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            var product = await _productTechSpecRepository.GetItemByKey(request.Id);
            #region Validation            
            if (product == null)
            {
                response.Success = false;
                response.Message = "The deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not found." });
            }
            #endregion
            else {
                await _productTechSpecRepository.Remove(product);
                response.Success = true;
                response.Message = "Creation Successful.";
            }
            
            return response;
        }
    }
}
