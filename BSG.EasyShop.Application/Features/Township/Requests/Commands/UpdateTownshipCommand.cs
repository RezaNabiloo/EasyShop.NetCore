using BSG.EasyShop.Application.DTOs.Township;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Requests.Commands
{
    public class UpdateTownshipCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public TownshipUpdateDTO TownshipUpdateDTO { get; set; }
    }
}
