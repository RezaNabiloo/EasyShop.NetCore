using BSG.EasyShop.Application.DTOs.Township;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Township.Requests.Commands
{
    public class UpdateTownshipCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
        public TownshipUpdateDTO TownshipUpdateDTO { get; set; }
    }
}
