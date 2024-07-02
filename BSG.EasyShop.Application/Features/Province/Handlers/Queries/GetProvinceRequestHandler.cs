using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Province;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Handlers.Queries
{
    public class GetProvinceRequestHandler : IRequestHandler<GetProvinceRequest, ProvinceDTO>
    {
        private readonly IProvinceRepository _ProvinceRepository;
        private readonly IMapper _mapper;

        public GetProvinceRequestHandler(IProvinceRepository ProvinceRepository, IMapper mapper)
        {
            _ProvinceRepository = ProvinceRepository;
            _mapper = mapper;
        }
        public async Task<ProvinceDTO> Handle(GetProvinceRequest request, CancellationToken cancellationToken)
        {
            var Province = await _ProvinceRepository.GetItemByKey(request.Id);
            return _mapper.Map<ProvinceDTO>(Province);
        }
    }
}
