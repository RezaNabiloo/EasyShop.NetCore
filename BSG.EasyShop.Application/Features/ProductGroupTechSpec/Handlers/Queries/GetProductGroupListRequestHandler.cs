using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Handlers.Queries
{
    public class GetProductGroupTechSpecListRequestHandler : IRequestHandler<GetProductGroupTechSpecListRequest, List<ProductGroupTechSpecDTO>>
    {
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;
        private readonly IMapper _mapper;


        // Use Repository to get data.
        public GetProductGroupTechSpecListRequestHandler(IProductGroupTechSpecRepository productGroupTechSpecRepository, IMapper mapper)
        {
            _productGroupTechSpecRepository = productGroupTechSpecRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductGroupTechSpecDTO>> Handle(GetProductGroupTechSpecListRequest request, CancellationToken cancellationToken)
        {
            var data = await _productGroupTechSpecRepository.GetAllItems();
            return _mapper.Map<List<ProductGroupTechSpecDTO>>(data);
        }
    }
}
