using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Requests.Commands
{
    public class DeleteProvinceCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
