using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Features.Brand.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Handlers.Queries
{
    public class GetBrandListRequestHandler : IRequestHandler<GetBrandListRequest, List<BrandListDTO>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper; 

        public GetBrandListRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<List<BrandListDTO>> Handle(GetBrandListRequest request, CancellationToken cancellationToken)
        {
            var brandList = await _brandRepository.GetAllItems();
            return _mapper.Map<List<BrandListDTO>>(brandList);
        }
    }
}
