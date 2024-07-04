using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.Models.Response;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Requests.Commands
{
    /// <summary>
    /// Update product request
    /// This command returns nothing that determind by Unit in MeiatR
    /// </summary>
    public class UpdateProductCommand:IRequest<CommandResponse<string>>
    {
        public long Id { get; set; }
        public ProductUpdateDTO ProductUpdateDTO { get; set; }

        public ProductConfirmDTO ProductConfirmDTO { get; set; }
    }
}
