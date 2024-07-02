using BSG.EasyShop.Application.DTOs.Country;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Requests.Commands
{
    public class UpdateCountryCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
        public CountryUpdateDTO CountryUpdateDTO { get; set; }
    }
}
