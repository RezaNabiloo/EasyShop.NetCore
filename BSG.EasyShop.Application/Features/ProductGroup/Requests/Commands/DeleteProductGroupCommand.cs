using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands
{
    public class DeleteProductGroupCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
