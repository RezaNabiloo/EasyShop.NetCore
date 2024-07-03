using AutoMapper;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.ProductImage.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;
using BSG.EasyShop.Application.Responses;

namespace BSG.EasyShop.Application.Features.ProductImage.Handlers.Commands
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, BaseCommandResponse>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public DeleteProductImageCommandHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var data = await _productImageRepository.GetItemByKey(request.Id);
            #region Validation            
            if (data == null)
            {
                throw new NotFoundException(nameof(data), request.Id);
            }
            #endregion
            await _productImageRepository.Remove(data);
            //return Unit.Value;
            return response;
        }
    }
}
