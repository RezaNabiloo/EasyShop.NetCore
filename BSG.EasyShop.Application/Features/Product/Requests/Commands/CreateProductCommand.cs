using BSG.EasyShop.Application.DTOs.Product;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Requests.Commands
{
    public class CreateProductCommand:IRequest<long>
    {
        public ProductCreateDTO ProductCreateDTO { get; set; }
    }
}
