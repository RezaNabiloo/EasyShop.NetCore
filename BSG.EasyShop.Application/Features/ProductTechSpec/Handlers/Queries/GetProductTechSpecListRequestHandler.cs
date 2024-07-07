using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductTechSpec;
using BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductTechSpec.Handlers.Queries
{
    public class GetProductTechSpecListRequestHandler : IRequestHandler<GetProductTechSpecListRequest, List<ProductTechSpecDTO>>
    {
        private readonly IProductTechSpecRepository _productTechSpecRepository;
        private readonly IMapper _mapper;


        // Use Repository to get data.
        public GetProductTechSpecListRequestHandler(IProductTechSpecRepository productTechSpecRepository, IMapper mapper)
        {
            _productTechSpecRepository = productTechSpecRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductTechSpecDTO>> Handle(GetProductTechSpecListRequest request, CancellationToken cancellationToken)
        {
            var data = await _productTechSpecRepository.GetAllItems();
            return _mapper.Map<List<ProductTechSpecDTO>>(data);
        }
    }
}
