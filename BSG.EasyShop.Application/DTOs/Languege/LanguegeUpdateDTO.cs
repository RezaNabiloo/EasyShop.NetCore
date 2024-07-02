using BSG.EasyShop.Application.DTOs.Common;

namespace BSG.EasyShop.Application.DTOs.Languege
{
    public class LanguegeUpdateDTO:BaseDTO,ILanguegeDTO
    {
        public string Title { get; set; }
        public string OriginalTitle { get; set; }


    }
}
