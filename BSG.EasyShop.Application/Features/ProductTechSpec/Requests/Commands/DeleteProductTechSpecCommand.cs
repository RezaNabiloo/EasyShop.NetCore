using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Commands
{
    public class DeleteProductTechSpecCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
