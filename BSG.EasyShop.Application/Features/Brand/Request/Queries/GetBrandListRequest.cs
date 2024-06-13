using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.DTOs.ProductGroup;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries
{
    public class GetBrandListRequest : IRequest<List<BrandListDTO>>
    {

    }
}
