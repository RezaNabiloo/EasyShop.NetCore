using BSG.EasyShop.Application.DTOs.Country;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Requests.Commands
{
    public class CreateCountryCommand:IRequest<BaseCommandResponse>
    {
        public CountryCreateDTO CountryCreateDTO { get; set; }
    }
}
