using BSG.EasyShop.Application.DTOs.Languege;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Requests.Commands
{
    public class CreateLanguegeCommand:IRequest<CommandResponse<long>>
    {
        public LanguegeCreateDTO LanguegeCreateDTO { get; set; }
    }
}
