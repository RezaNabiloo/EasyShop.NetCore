using AutoMapper;
using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.Features.Product.Requests.Queries;
using BSG.EasyShop.Application.Contracts.Persistence;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductListDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        // Use Repository to get data.
        public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDTO>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetAllItems();
            return _mapper.Map<List<ProductListDTO>>(data);
        }
    }
}
