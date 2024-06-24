using BSG.EasyShop.Application.DTOs.Color;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.Features.Color.Requests.Queries
{
    public class GetColorListRequest:IRequest<List<ColorListDTO>>
    {
    }
}
