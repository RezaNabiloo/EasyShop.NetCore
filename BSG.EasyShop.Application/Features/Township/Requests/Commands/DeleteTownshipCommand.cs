using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Requests.Commands
{
    public class DeleteTownshipCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
    }
}
