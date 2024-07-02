using BSG.EasyShop.Application.DTOs.Province;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Requests.Commands
{
    public class UpdateProvinceCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
        public ProvinceUpdateDTO ProvinceUpdateDTO { get; set; }
    }
}
