using BSG.EasyShop.Application.DTOs.Color;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Requests.Commands
{
    public class UpdateColorCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
        public ColorUpdateDTO ColorUpdateDTO { get; set; }
    }
}
