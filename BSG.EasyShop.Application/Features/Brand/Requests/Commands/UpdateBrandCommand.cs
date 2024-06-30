using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Requests.Commands
{
    public class UpdateBrandCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
        public BrandUpdateDTO BrandUpdateDTO { get; set; }
    }
}
