using BSG.EasyShop.Application.DTOs.Languege;
using BSG.EasyShop.Application.Responses;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Requests.Commands
{
    public class UpdateLanguegeCommand:IRequest<BaseCommandResponse>
    {
        public long Id { get; set; }
        public LanguegeUpdateDTO LanguegeUpdateDTO { get; set; }
    }
}
