using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Country.Requests.Commands
{
    public class DeleteCountryCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
    }
}
