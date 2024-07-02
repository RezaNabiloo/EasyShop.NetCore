using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Township;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Handlers.Queries
{
    public class GetTownshipRequestHandler : IRequestHandler<GetTownshipRequest, TownshipDTO>
    {
        private readonly ITownshipRepository _TownshipRepository;
        private readonly IMapper _mapper;

        public GetTownshipRequestHandler(ITownshipRepository TownshipRepository, IMapper mapper)
        {
            _TownshipRepository = TownshipRepository;
            _mapper = mapper;
        }
        public async Task<TownshipDTO> Handle(GetTownshipRequest request, CancellationToken cancellationToken)
        {
            var Township = await _TownshipRepository.GetItemByKey(request.Id);
            return _mapper.Map<TownshipDTO>(Township);
        }
    }
}
