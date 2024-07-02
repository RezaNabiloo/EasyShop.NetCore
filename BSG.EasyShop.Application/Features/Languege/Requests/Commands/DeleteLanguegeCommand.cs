using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Requests.Commands
{
    public class DeleteLanguegeCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
    }
}
