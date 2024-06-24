using BSG.EasyShop.Application.DTOs.Brand;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Requests.Queries
{
    public class GetBrandListRequest : IRequest<List<BrandListDTO>>
    {

    }
}
  