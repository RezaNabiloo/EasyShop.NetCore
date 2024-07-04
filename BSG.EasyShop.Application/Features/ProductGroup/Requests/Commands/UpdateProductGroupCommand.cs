using BSG.EasyShop.Application.DTOs.ProductGroup;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands
{
    /// <summary>
    /// This command returns nothing that determind by Unit in MeiatR
    /// </summary>
    public class UpdateProductGroupCommand : IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public ProductGroupUpdateDTO ProductGroupUpdateDTO { get; set; }
    }
}
