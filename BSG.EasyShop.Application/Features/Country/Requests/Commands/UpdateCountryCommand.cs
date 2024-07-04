using BSG.EasyShop.Application.DTOs.Country;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Requests.Commands
{
    public class UpdateCountryCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public CountryUpdateDTO CountryUpdateDTO { get; set; }
    }
}
