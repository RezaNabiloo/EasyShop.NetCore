using BSG.EasyShop.Application.DTOs.ProductGroupSize;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.ProductGroupSize.Requests.Commands
{
    /// <summary>
    /// This command returns nothing that determind by Unit in MeiatR
    /// </summary>
    public class UpdateProductGroupSizeCommand : IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public ProductGroupSizeUpdateDTO ProductGroupSizeUpdateDTO { get; set; }
    }
}
