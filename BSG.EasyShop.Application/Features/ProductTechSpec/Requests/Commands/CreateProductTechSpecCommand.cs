using BSG.EasyShop.Application.DTOs.ProductTechSpec;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Commands
{
    public class CreateProductTechSpecCommand:IRequest<CommandResponse<long>>
    {
        public ProductTechSpecCreateDTO ProductTechSpecCreateDTO { get; set; }
    }
}
