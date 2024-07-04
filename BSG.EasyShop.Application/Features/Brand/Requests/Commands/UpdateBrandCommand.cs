using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Requests.Commands
{
    public class UpdateBrandCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public BrandUpdateDTO BrandUpdateDTO { get; set; }
    }
}
