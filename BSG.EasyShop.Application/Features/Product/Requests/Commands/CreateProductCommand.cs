using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Requests.Commands
{
    public class CreateProductCommand:IRequest<CommandResponse<long>>
    {
        public ProductCreateDTO ProductCreateDTO { get; set; }
    }
}
