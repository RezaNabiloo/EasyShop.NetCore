using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Requests.Commands
{
    public class DeleteCountryCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
