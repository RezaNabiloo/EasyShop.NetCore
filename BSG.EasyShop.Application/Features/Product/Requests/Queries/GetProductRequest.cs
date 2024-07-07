using BSG.EasyShop.Application.DTOs.Product;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Requests.Queries
{
    public class GetProductRequest : IRequest<IProductDTO>
    {
        public long Id { get; set; }
    }
}
