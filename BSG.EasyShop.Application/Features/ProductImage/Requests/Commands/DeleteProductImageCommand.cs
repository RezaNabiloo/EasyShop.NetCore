using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductImage.Requests.Commands
{
    public class DeleteProductImageCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
    }
}
