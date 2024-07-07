using AutoMapper;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductImage.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;
using BSG.EasyShop.Application.Models.Response;
using BSG.EasyShop.Domain.Enum;

namespace BSG.EasyShop.Application.Features.ProductImage.Handlers.Commands
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, CommandResponse<string>>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public DeleteProductImageCommandHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<string>> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<string>();
            var data = await _productImageRepository.GetItemByKey(request.Id);
            #region Validation            
            if (data == null)
            {
                response.Success = false;
                response.Message = "The deletion was failed.";
                response.ResultMessages.Add(new ResultMessage { MessageType = ResultMessageType.Validation, Message = "Item dose not exist." });
            }
            #endregion
            else
            {
                await _productImageRepository.Remove(data);
                response.Success = true;
                response.Message = "The deletion was successful.";
            }
            return response;
        }
    }
}
