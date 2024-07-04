using BSG.EasyShop.Application.DTOs.ProductGroup;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands
{
    public class CreateProductGroupCommand:IRequest<CommandResponse<long>>
    {
        public ProductGroupCreateDTO ProductGroupCreateDTO { get; set; }
    }
}
