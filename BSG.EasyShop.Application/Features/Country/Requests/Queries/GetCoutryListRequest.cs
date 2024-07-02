using BSG.EasyShop.Application.DTOs.Country;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Requests.Queries
{
    public class GetCountryListRequest : IRequest<List<CountryDTO>>
    {

    }
}
  