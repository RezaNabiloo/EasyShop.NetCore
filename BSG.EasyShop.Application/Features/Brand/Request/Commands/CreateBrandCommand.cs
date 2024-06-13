using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Request.Commands
{
    public class CreateBrandCommand:IRequest<BaseCommandResponse>
    {
        public BrandCreateDTO BrandCreateDTO { get; set; }
    }
}
