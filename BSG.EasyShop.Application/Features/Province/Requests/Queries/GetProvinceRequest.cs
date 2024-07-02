using BSG.EasyShop.Application.DTOs.Province;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries
{
    public class GetProvinceRequest : IRequest<ProvinceDTO>
    {
        public long Id { get; set; }
    }
}
