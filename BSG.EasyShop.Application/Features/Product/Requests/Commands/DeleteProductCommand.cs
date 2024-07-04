using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Requests.Commands
{
    public class DeleteProductCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
