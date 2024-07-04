using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Requests.Commands
{
    public class DeleteBrandCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
