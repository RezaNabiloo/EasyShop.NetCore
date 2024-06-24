using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Handlers.Queries
{
    public class GetBrandRequestHandler : IRequestHandler<GetBrandRequest, ProductImageDTO>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<ProductImageDTO> Handle(GetBrandRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetItemByKey(request.Id);
            return _mapper.Map<ProductImageDTO>(brand);
        }
    }
}
