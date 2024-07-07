using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Commands
{
    public class CreateProductGroupTechSpecCommand:IRequest<CommandResponse<long>>
    {
        public ProductGroupTechSpecCreateDTO ProductGroupTechSpecCreateDTO { get; set; }
    }
}
