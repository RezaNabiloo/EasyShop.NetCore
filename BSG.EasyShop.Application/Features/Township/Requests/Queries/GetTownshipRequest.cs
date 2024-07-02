using BSG.EasyShop.Application.DTOs.Township;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries
{
    public class GetTownshipRequest : IRequest<TownshipDTO>
    {
        public long Id { get; set; }
    }
}
