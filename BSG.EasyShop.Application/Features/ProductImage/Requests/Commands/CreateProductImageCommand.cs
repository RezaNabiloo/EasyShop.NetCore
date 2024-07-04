using BSG.EasyShop.Application.DTOs.ProductImage;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductImage.Requests.Commands
{
    public class CreateProductImageCommand:IRequest<CommandResponse<long>>
    {
        public ProductImageCreateDTO ProductImageCreateDTO { get; set; }
    }
}
