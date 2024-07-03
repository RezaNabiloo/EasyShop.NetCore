using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Languege;
using BSG.EasyShop.Application.Features.Languege.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.Features.Languege.Handlers.Queries
{
    public class GetLanguegeRequestHandler : IRequestHandler<GetLanguegeRequest, LanguegeDTO>
    {
        private readonly ILanguegeRepository _languegeRepository;
        private readonly IMapper _mapper;

        public GetLanguegeRequestHandler(ILanguegeRepository languegeRepository, IMapper mapper)
        {
            _languegeRepository = languegeRepository;
            _mapper = mapper;
        }
        public async Task<LanguegeDTO> Handle(GetLanguegeRequest request, CancellationToken cancellationToken)
        {
            var languege = await _languegeRepository.GetItemByKey(request.Id);
            return _mapper.Map<LanguegeDTO>(languege);            
        }
    }
}
