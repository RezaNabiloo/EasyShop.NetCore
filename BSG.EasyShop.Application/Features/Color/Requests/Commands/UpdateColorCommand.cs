using BSG.EasyShop.Application.DTOs.Color;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Requests.Commands
{
    public class UpdateColorCommand:IRequest<CommandResponse<string?>>
    {
        public long Id { get; set; }
        public ColorUpdateDTO ColorUpdateDTO { get; set; }
    }
}
