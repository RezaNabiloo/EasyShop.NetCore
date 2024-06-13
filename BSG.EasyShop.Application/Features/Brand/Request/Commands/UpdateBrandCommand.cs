using BSG.EasyShop.Application.DTOs.Brand;
using MediatR;
using System.Reflection.PortableExecutable;

namespace BSG.EasyShop.Application.Features.Brand.Request.Commands
{
    public class UpdateBrandCommand:IRequest<Unit>
    {
        public long Id { get; set; }
        public BrandUpdateDTO BrandUpdateDTO { get; set; }
    }
}
