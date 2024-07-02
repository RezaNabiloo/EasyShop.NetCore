using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
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
    public class GetColorRequestHandler : IRequestHandler<GetColorRequest, ColorDTO>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetColorRequestHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<ColorDTO> Handle(GetColorRequest request, CancellationToken cancellationToken)
        {
            var color = await _colorRepository.GetItemByKey(request.Id);
            return _mapper.Map<ColorDTO>(color);            
        }
    }
}
