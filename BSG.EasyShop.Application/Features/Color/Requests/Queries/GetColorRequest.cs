using BSG.EasyShop.Application.DTOs.Color;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Requests.Queries
{
    public class GetColorRequest:IRequest<ColorDTO>
    {
        public long Id { get; set; }
    }
}
