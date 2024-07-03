using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.DTOs.Languege
{
    public class LanguegeCreateDTO:ILanguegeDTO
    {
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public string OriginalTitle { get; set; }

    }
}
