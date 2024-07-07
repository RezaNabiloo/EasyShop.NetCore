using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Commands
{
    public class DeleteProductGroupTechSpecCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
