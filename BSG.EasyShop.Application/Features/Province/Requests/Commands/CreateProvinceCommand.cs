using BSG.EasyShop.Application.DTOs.Province;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Requests.Commands
{
    public class CreateProvinceCommand:IRequest<BaseCommandResponse>
    {
        public ProvinceCreateDTO ProvinceCreateDTO { get; set; }
    }
}
