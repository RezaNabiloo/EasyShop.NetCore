using BSG.EasyShop.Application.DTOs.ProductImage;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductImage.Requests.Commands
{
    public class CreateProductImageCommand:IRequest<BaseCommandResponse>
    {
        public ProductImageCreateDTO ProductImageCreateDTO { get; set; }
    }
}
