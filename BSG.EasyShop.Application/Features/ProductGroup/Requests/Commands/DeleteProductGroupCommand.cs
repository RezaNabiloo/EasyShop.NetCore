using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.Features.ProductGroup.Requests.Commands
{
    public class DeleteProductGroupCommand:IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
