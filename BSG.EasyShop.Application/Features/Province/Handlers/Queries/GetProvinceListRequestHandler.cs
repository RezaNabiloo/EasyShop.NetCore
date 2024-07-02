using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Province;
using BSG.EasyShop.Application.Features.Province.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Handlers.Queries
{
    public class GetProvinceListRequestHandler : IRequestHandler<GetProvinceListRequest, List<ProvinceDTO>>
    {
        private readonly IProvinceRepository _ProvinceRepository;
        private readonly IMapper _mapper; 

        public GetProvinceListRequestHandler(IProvinceRepository ProvinceRepository, IMapper mapper)
        {
            _ProvinceRepository = ProvinceRepository;
            _mapper = mapper;
        }
        public async Task<List<ProvinceDTO>> Handle(GetProvinceListRequest request, CancellationToken cancellationToken)
        {
            var ProvinceList = await _ProvinceRepository.GetAllItems();
            return _mapper.Map<List<ProvinceDTO>>(ProvinceList);
        }
    }
}
