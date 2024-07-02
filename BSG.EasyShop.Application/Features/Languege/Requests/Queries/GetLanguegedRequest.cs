using BSG.EasyShop.Application.DTOs.Languege;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Queries
{
    public class GetLanguegeRequest : IRequest<LanguegeDTO>
    {
        public long Id { get; set; }
    }
}
