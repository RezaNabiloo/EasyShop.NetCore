using BSG.EasyShop.Application.DTOs.Province;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Requests.Commands
{
    public class UpdateProvinceCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public ProvinceUpdateDTO ProvinceUpdateDTO { get; set; }
    }
}
