using BSG.EasyShop.Application.DTOs.Township;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Requests.Commands
{
    public class CreateTownshipCommand:IRequest<BaseCommandResponse>
    {
        public TownshipCreateDTO TownshipCreateDTO { get; set; }
    }
}
