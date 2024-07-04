using BSG.EasyShop.Application.DTOs.Township;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Requests.Commands
{
    public class CreateTownshipCommand:IRequest<CommandResponse<long>>
    {
        public TownshipCreateDTO TownshipCreateDTO { get; set; }
    }
}
