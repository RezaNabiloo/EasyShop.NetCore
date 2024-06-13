using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Requests.Commands
{
    public class DeleteBrandCommand:IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
