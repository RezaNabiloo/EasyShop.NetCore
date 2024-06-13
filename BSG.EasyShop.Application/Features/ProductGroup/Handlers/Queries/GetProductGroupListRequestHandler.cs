using AutoMapper;
using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.DTOs.ProductGroup;
using BSG.EasyShop.Application.Features.Product.Requests.Queries;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using BSG.EasyShop.Application.Contracts.Persistance;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Handlers.Queries
{
    public class GetProductGroupListRequestHandler : IRequestHandler<GetProductGroupListRequest, List<ProductGroupDTO>>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;


        // Use Repository to get data.
        public GetProductGroupListRequestHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductGroupDTO>> Handle(GetProductGroupListRequest request, CancellationToken cancellationToken)
        {
            var data = await _productGroupRepository.GetAllItems();
            return _mapper.Map<List<ProductGroupDTO>>(data);
        }
    }
}
