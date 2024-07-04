using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductImage.Requests.Commands
{
    public class DeleteProductImageCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
