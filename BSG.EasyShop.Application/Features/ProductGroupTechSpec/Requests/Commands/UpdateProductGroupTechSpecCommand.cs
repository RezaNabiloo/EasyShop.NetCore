using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupTechSpec.Requests.Commands
{
    /// <summary>
    /// This command returns nothing that determind by Unit in MeiatR
    /// </summary>
    public class UpdateProductGroupTechSpecCommand : IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public ProductGroupTechSpecUpdateDTO ProductGroupTechSpecUpdateDTO { get; set; }
    }
}
