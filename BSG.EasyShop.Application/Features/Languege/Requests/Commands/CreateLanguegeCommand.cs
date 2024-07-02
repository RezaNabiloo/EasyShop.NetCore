using BSG.EasyShop.Application.DTOs.Languege;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Requests.Commands
{
    public class CreateLanguegeCommand:IRequest<BaseCommandResponse>
    {
        public LanguegeCreateDTO LanguegeCreateDTO { get; set; }
    }
}
