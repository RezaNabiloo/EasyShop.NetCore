using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Features.Brand.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Handlers.Queries
{
    public class GetBrandListRequestHandler : IRequestHandler<GetBrandListRequest, List<BrandDTO>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper; 

        public GetBrandListRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<List<BrandDTO>> Handle(GetBrandListRequest request, CancellationToken cancellationToken)
        {
            var brandList = await _brandRepository.GetAllItems();
            return _mapper.Map<List<BrandDTO>>(brandList);
        }
    }
}
