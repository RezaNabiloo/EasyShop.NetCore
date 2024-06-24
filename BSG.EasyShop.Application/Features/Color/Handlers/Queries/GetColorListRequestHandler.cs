using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.DTOs.Color;
using BSG.EasyShop.Application.Features.Color.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.Features.Color.Handlers.Queries
{
    public class GetColorListRequestHandler : IRequestHandler<GetColorListRequest, List<ColorListDTO>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        public GetColorListRequestHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        

        public async Task<List<ColorListDTO>> Handle(GetColorListRequest request, CancellationToken cancellationToken)
        {
            var colorList = await _colorRepository.GetAllItems();
            return _mapper.Map<List<ColorListDTO>>(colorList);
        }
    }
}
