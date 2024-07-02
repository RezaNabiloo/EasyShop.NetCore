using AutoMapper;
using BSG.EasyShop.Application.Exceptions;
using BSG.EasyShop.Application.Features.Product.Requests.Commands;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetItemByKey(request.Id);
            #region Validation            
            if (data == null)
            {
                throw new NotFoundException(nameof(data), request.Id);
            }
            #endregion
            await _productRepository.Remove(data);
            return Unit.Value;
        }
    }
}
