using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Queries
{
    public class GetProductGroupTechSpecListRequest : IRequest<List<ProductGroupTechSpecDTO>>
    {
    }
}
