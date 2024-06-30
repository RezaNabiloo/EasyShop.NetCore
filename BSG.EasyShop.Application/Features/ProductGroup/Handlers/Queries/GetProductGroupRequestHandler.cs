using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.ProductGroup;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Handlers.Queries
{
    public class GetProductGroupRequestHandler : IRequestHandler<GetProductGroupRequest, ProductGroupDTO>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMapper _mapper;

        public GetProductGroupRequestHandler(IProductGroupRepository productGroupRepository, IMapper mapper)
        {
            _productGroupRepository = productGroupRepository;
            _mapper = mapper;
        }

        public async Task<ProductGroupDTO> Handle(GetProductGroupRequest request, CancellationToken cancellationToken)
        {
            var data = await _productGroupRepository.GetItemByKey(request.Id);
            return _mapper.Map<ProductGroupDTO>(data);
        }
    }
}
