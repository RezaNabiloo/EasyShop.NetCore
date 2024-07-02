using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Requests.Commands
{
    public class DeleteProvinceCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
    }
}
