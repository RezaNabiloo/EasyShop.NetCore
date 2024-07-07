using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductTechSpec.Requests.Commands
{
    /// <summary>
    /// This command returns nothing that determind by Unit in MeiatR
    /// </summary>
    public class UpdateProductTechSpecCommand : IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public ProductTechSpecUpdateDTO ProductTechSpecUpdateDTO { get; set; }
    }
}
