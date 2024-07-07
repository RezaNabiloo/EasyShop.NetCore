using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductTechSpec;
using BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Handlers.Queries
{
    public class GetProductTechSpecRequestHandler : IRequestHandler<GetProductTechSpecRequest, ProductTechSpecDTO>
    {
        private readonly IProductTechSpecRepository _productTechSpecRepository;
        private readonly IMapper _mapper;

        public GetProductTechSpecRequestHandler(IProductTechSpecRepository productTechSpecRepository, IMapper mapper)
        {
            _productTechSpecRepository = productTechSpecRepository;
            _mapper = mapper;
        }

        public async Task<ProductTechSpecDTO> Handle(GetProductTechSpecRequest request, CancellationToken cancellationToken)
        {
            var data = await _productTechSpecRepository.GetItemByKey(request.Id);
            return _mapper.Map<ProductTechSpecDTO>(data);
        }
    }
}
