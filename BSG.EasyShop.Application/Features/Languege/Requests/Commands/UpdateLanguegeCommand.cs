using BSG.EasyShop.Application.DTOs.Languege;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Requests.Commands
{
    public class UpdateLanguegeCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public LanguegeUpdateDTO LanguegeUpdateDTO { get; set; }
    }
}
