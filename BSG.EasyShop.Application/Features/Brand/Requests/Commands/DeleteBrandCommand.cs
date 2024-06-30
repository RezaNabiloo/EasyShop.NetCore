using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Requests.Commands
{
    public class DeleteBrandCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
    }
}
