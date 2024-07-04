using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Requests.Commands
{
    public class DeleteTownshipCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
