using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductImage;
using BSG.EasyShop.Application.Features.ProductImage.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductImage.Handlers.Queries
{
    public class GetProductImageRequestHandler : IRequestHandler<GetProductImageRequest, ProductImageDTO>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public GetProductImageRequestHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<ProductImageDTO> Handle(GetProductImageRequest request, CancellationToken cancellationToken)
        {
            var data = await _productImageRepository.GetItemByKey(request.Id);
            return _mapper.Map<ProductImageDTO>(data);
        }
    }
}
