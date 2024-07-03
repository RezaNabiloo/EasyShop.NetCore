using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Languege;
using BSG.EasyShop.Application.Features.Languege.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Handlers.Queries
{
    public class GetLanguegeListRequestHandler : IRequestHandler<GetLanguegeListRequest, List<LanguegeDTO>>
    {
        private readonly ILanguegeRepository _languegeRepository;
        private readonly IMapper _mapper;
        public GetLanguegeListRequestHandler(ILanguegeRepository languegeRepository, IMapper mapper)
        {
            _languegeRepository = languegeRepository;
            _mapper = mapper;
        }
        

        public async Task<List<LanguegeDTO>> Handle(GetLanguegeListRequest request, CancellationToken cancellationToken)
        {
            var languegeList = await _languegeRepository.GetAllItems();
            return _mapper.Map<List<LanguegeDTO>>(languegeList);
        }
    }
}
