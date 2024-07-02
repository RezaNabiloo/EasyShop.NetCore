using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Township;
using BSG.EasyShop.Application.Features.Township.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Handlers.Queries
{
    public class GetTownshipListRequestHandler : IRequestHandler<GetTownshipListRequest, List<TownshipDTO>>
    {
        private readonly ITownshipRepository _TownshipRepository;
        private readonly IMapper _mapper; 

        public GetTownshipListRequestHandler(ITownshipRepository TownshipRepository, IMapper mapper)
        {
            _TownshipRepository = TownshipRepository;
            _mapper = mapper;
        }
        public async Task<List<TownshipDTO>> Handle(GetTownshipListRequest request, CancellationToken cancellationToken)
        {
            var TownshipList = await _TownshipRepository.GetAllItems();
            return _mapper.Map<List<TownshipDTO>>(TownshipList);
        }
    }
}
