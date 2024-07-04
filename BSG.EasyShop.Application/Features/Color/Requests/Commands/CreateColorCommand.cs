using BSG.EasyShop.Application.DTOs.Color;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Requests.Commands
{
    public class CreateColorCommand:IRequest<CommandResponse<long>>
    {
        public ColorCreateDTO ColorCreateDTO { get; set; }
    }
}
