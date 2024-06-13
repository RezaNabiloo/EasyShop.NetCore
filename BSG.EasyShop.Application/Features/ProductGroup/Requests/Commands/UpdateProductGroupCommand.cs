using BSG.EasyShop.Application.DTOs.ProductGroup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands
{
    /// <summary>
    /// This command returns nothing that determind by Unit in MeiatR
    /// </summary>
    public class UpdateProductGroupCommand : IRequest<Unit>
    {
        public ProductGroupUpdateDTO ProductGroupUpdateDTO { get; set; }
    }
}
