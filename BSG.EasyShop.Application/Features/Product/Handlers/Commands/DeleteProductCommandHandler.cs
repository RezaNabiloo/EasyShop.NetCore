using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Features.Product.Requests.Commands;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, CommandResponse<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            var product = await _productRepository.GetItemByKey(request.Id);
            #region Validation            
            if (product == null)
            {
                //throw new NotFoundException(nameof(data), request.Id);
                response.Success = false;
                response.Message = "The deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not found." });
            }
            #endregion
            else
            {
                await _productRepository.Remove(product);
                response.Success = true;
                response.Message = "The deletion was successful.";
            }
            return response;
        }
    }
}
