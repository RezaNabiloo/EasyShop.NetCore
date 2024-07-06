using BSG.EasyShop.Application.DTOs.Color;
using MediatR;

namespace BSG.EasyShop.Application.Features.Color.Requests.Queries
{
    public class GetColorListRequest:IRequest<List<ColorDTO>>
    {
    }
}
