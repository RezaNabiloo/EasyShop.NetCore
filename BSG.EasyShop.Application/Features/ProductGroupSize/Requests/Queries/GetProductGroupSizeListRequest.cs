using BSG.EasyShop.Application.DTOs.ProductGroupSize;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Queries
{
    public class GetProductGroupSizeListRequest : IRequest<List<ProductGroupSizeDTO>>
    {
    }
}
