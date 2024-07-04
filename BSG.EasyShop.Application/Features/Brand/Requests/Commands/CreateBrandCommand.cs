using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Requests.Commands
{
    public class CreateBrandCommand:IRequest<CommandResponse<long>>
    {
        public BrandCreateDTO BrandCreateDTO { get; set; }
    }
}
