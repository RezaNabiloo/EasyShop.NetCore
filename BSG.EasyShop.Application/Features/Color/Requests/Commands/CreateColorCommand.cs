using BSG.EasyShop.Application.DTOs.Color;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Requests.Commands
{
    public class CreateColorCommand:IRequest<BaseCommandResponse>
    {
        public ColorCreateDTO ColorCreateDTO { get; set; }
    }
}
