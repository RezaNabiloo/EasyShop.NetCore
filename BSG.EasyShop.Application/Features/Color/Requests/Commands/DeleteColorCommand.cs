using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Requests.Commands
{
    public class DeleteColorCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
