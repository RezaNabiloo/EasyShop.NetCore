using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.ProductGroup;
using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Handlers.Queries
{
    public class GetProductGroupTechSpecRequestHandler : IRequestHandler<GetProductGroupTechSpecRequest, ProductGroupTechSpecDTO>
    {
        private readonly IProductGroupTechSpecRepository _productGroupTechSpecRepository;
        private readonly IMapper _mapper;

        public GetProductGroupTechSpecRequestHandler(IProductGroupTechSpecRepository productGroupTechSpecRepository, IMapper mapper)
        {
            _productGroupTechSpecRepository = productGroupTechSpecRepository;
            _mapper = mapper;
        }

        public async Task<ProductGroupTechSpecDTO> Handle(GetProductGroupTechSpecRequest request, CancellationToken cancellationToken)
        {
            var data = await _productGroupTechSpecRepository.GetItemByKey(request.Id);
            return _mapper.Map<ProductGroupTechSpecDTO>(data);
        }
    }
}
