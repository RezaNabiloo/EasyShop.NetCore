using BSG.EasyShop.Application.DTOs.ProductGroupSize;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Commands
{
    public class CreateProductGroupSizeCommand : IRequest<CommandResponse<long>>
    {
        public ProductGroupSizeCreateDTO ProductGroupSizeCreateDTO { get; set; }
    }
}
