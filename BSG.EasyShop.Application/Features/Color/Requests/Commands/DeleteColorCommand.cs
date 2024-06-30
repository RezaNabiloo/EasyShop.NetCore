using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Requests.Commands
{
    public class DeleteColorCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
    }
}
