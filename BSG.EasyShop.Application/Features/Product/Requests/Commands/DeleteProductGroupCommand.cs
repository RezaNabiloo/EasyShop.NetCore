using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Requests.Commands
{
    public class DeleteProductCommand:IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
