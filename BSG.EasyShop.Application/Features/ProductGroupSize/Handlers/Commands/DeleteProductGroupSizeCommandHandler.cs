using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
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
            var data = await _productGroupSizeRepository.GetItemByKey(request.Id);
            #region Validation            
            if (data == null)
            {
                response.Success = false;                
                response.Message = "Item not found.";
            }
            #endregion
            else 
            {
                await _productGroupSizeRepository.Remove(data);
                response.Success = true;
                response.Message = "Item deleted successfully.";
            }
            
            return response;
        }
    }
}
