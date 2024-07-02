using AutoMapper;
using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.DTOs.Country;
using BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Handlers.Queries
{
    public class GetCountryRequestHandler : IRequestHandler<GetCountryRequest, CountryDTO>
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly IMapper _mapper;

        public GetCountryRequestHandler(ICountryRepository CountryRepository, IMapper mapper)
        {
            _CountryRepository = CountryRepository;
            _mapper = mapper;
        }
        public async Task<CountryDTO> Handle(GetCountryRequest request, CancellationToken cancellationToken)
        {
            var Country = await _CountryRepository.GetItemByKey(request.Id);
            return _mapper.Map<CountryDTO>(Country);
        }
    }
}
