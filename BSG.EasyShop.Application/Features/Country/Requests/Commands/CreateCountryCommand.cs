using BSG.EasyShop.Application.DTOs.Country;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Requests.Commands
{
    public class CreateCountryCommand:IRequest<CommandResponse<long>>
    {
        public CountryCreateDTO CountryCreateDTO { get; set; }
    }
}
