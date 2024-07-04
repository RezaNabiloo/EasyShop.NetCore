using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Commands
{
    public class DeleteProductGroupSizeCommand : IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
