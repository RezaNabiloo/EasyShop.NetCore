using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductImage;
using BSG.EasyShop.Application.Features.ProductImage.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductImage.Handlers.Queries
{
    public class GetProductImageListRequestHandler : IRequestHandler<GetProductImageListRequest, List<ProductImageDTO>>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;


        // Use Repository to get data.
        public GetProductImageListRequestHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductImageDTO>> Handle(GetProductImageListRequest request, CancellationToken cancellationToken)
        {
            var data = await _productImageRepository.GetAllItems();
            return _mapper.Map<List<ProductImageDTO>>(data);
        }
    }
}
