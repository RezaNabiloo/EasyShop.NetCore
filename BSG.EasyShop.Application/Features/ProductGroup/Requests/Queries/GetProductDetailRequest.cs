
using BSG.EasyShop.Application.DTOs.ProductGroup;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries
{
    public class GetProductGroupDetailRequest : IRequest<ProductGroupDTO>
    {
        public long Id { get; set; }
    }
}
