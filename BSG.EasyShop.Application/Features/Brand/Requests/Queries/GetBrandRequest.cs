using BSG.EasyShop.Application.DTOs.Brand;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries
{
    public class GetBrandRequest : IRequest<BrandDTO>
    {
        public long Id { get; set; }
    }
}
