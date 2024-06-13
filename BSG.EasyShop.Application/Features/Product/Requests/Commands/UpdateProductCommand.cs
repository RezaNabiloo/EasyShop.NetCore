using BSG.EasyShop.Application.DTOs.Product;
using MediatR;

namespace BSG.EasyShop.Application.Features.Product.Requests.Commands
{
    /// <summary>
    /// Update product request
    /// This command returns nothing that determind by Unit in MeiatR
    /// </summary>
    public class UpdateProductCommand:IRequest<Unit>
    {
        public long Id { get; set; }
        public ProductUpdateDTO ProductUpdateDTO { get; set; }

        public ProductConfirmDTO ProductConfirmDTO { get; set; }
    }
}
