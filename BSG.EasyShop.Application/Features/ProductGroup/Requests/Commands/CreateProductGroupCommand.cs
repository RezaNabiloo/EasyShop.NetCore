using BSG.EasyShop.Application.DTOs.ProductGroup;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands
{
    public class CreateProductGroupCommand:IRequest<long>
    {
        public ProductGroupCreateDTO ProductGroupCreateDTO { get; set; }
    }
}
