using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.Color;
using BSG.EasyShop.Application.Features.Color.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Handlers.Queries
{
    public class GetColorListRequestHandler : IRequestHandler<GetColorListRequest, List<ColorDTO>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        public GetColorListRequestHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        

        public async Task<List<ColorDTO>> Handle(GetColorListRequest request, CancellationToken cancellationToken)
        {
            var colorList = await _colorRepository.GetAllItems();
            return _mapper.Map<List<ColorDTO>>(colorList);
        }
    }
}
