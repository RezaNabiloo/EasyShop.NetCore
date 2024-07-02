using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Country;
using BSG.EasyShop.Application.Features.Country.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Handlers.Queries
{
    public class GetCountryListRequestHandler : IRequestHandler<GetCountryListRequest, List<CountryDTO>>
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly IMapper _mapper; 

        public GetCountryListRequestHandler(ICountryRepository CountryRepository, IMapper mapper)
        {
            _CountryRepository = CountryRepository;
            _mapper = mapper;
        }
        public async Task<List<CountryDTO>> Handle(GetCountryListRequest request, CancellationToken cancellationToken)
        {
            var CountryList = await _CountryRepository.GetAllItems();
            return _mapper.Map<List<CountryDTO>>(CountryList);
        }
    }
}
