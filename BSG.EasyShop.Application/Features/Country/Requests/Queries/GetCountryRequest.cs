using BSG.EasyShop.Application.DTOs.Country;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries
{
    public class GetCountryRequest : IRequest<CountryDTO>
    {
        public long Id { get; set; }
    }
}
