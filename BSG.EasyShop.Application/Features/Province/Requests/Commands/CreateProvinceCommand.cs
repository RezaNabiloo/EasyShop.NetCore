using BSG.EasyShop.Application.DTOs.Province;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Province.Requests.Commands
{
    public class CreateProvinceCommand:IRequest<CommandResponse<long>>
    {
        public ProvinceCreateDTO ProvinceCreateDTO { get; set; }
    }
}
