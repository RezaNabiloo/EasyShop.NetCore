using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Languege.Requests.Commands
{
    public class DeleteLanguegeCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
    }
}
