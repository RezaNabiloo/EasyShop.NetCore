using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupSize.Handlers.Commands
{
    public class DeleteProductGroupSizeCommandHandler : IRequestHandler<DeleteProductGroupSizeCommand, CommandResponse<string>>
    {
        private readonly IProductGroupSizeRepository _productGroupSizeRepository;
        private readonly IMapper _mapper;

        public DeleteProductGroupSizeCommandHandler(IProductGroupSizeRepository productGroupSizeRepository, IMapper mapper)
        {
            _productGroupSizeRepository = productGroupSizeRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteProductGroupSizeCommand request, CancellationToken cancellationToken)
        {
            var response =new CommandResponse<string>();
            var productGroupSize = await _productGroupSizeRepository.GetItemByKey(request.Id);
            #region Validation            
            if (productGroupSize == null)
            {
                response.Success = false;
                response.Message = "The deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
            }
            #endregion
            else 
            {
                await _productGroupSizeRepository.Remove(productGroupSize);
                response.Success = true;
                response.Message = "Item deleted successfully.";
            }
            
            return response;
        }
    }
}
