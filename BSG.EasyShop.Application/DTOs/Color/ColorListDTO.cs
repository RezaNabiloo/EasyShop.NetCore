using BSG.EasyShop.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.DTOs.Color
{
    public class ColorListDTO:BaseDTO
    {
        public string? Title { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
