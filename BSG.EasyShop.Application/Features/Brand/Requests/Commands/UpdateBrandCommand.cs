using BSG.EasyShop.Application.DTOs.Brand;
using MediatR;

namespace BSG.EasyShop.Application.Features.Brand.Requests.Commands
{
    public class UpdateBrandCommand:IRequest<Unit>
    {
        public long Id { get; set; }
        public BrandUpdateDTO BrandUpdateDTO { get; set; }
    }
}
