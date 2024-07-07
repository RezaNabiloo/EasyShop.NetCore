using AutoMapper;
using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.Features.Product.Requests.Queries;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Handlers.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductRequest, IProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IProductDTO> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetItemByKey(request.Id);
            return _mapper.Map<IProductDTO>(data);
        }
    }
}
