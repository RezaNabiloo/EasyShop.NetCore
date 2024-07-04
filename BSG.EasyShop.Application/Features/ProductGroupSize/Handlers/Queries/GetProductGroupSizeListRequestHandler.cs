using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductGroupSize;
using BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupSize.Handlers.Queries
{
    public class GetProductGroupSizeListRequestHandler : IRequestHandler<GetProductGroupSizeListRequest, List<ProductGroupSizeDTO>>
    {
        private readonly IProductGroupSizeRepository _productGroupSizeRepository;
        private readonly IMapper _mapper;


        // Use Repository to get data.
        public GetProductGroupSizeListRequestHandler(IProductGroupSizeRepository productGroupSizeRepository, IMapper mapper)
        {
            _productGroupSizeRepository = productGroupSizeRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductGroupSizeDTO>> Handle(GetProductGroupSizeListRequest request, CancellationToken cancellationToken)
        {
            var data = await _productGroupSizeRepository.GetAllItems();
            return _mapper.Map<List<ProductGroupSizeDTO>>(data);
        }
    }
}
