using AutoMapper;
using BSG.EasyShop.Application.DTOs.ProductGroup;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using BSG.EasyShop.Application.Contracts.Persistance;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Handlers.Queries
{
    public class GetProductGroupDetailRequestHandler : IRequestHandler<GetProductGroupDetailRequest, ProductGroupDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public GetProductGroupDetailRequestHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<ProductGroupDTO> Handle(GetProductGroupDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await _productGroupRepository.GetItemByKey(request.Id);
            return _mapper.Map<ProductGroupDTO>(data);
        }
    }
}
