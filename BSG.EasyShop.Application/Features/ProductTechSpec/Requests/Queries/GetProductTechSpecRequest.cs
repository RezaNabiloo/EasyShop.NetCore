
using BSG.EasyShop.Application.DTOs.ProductTechSpec;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Queries
{
    public class GetProductTechSpecRequest : IRequest<ProductTechSpecDTO>
    {
        public long Id { get; set; }
    }
}
