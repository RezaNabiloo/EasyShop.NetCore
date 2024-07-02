using BSG.EasyShop.Application.DTOs.Common;

namespace BSG.EasyShop.Application.DTOs.Languege
{
    public class LanguegeDTO:BaseDTO,ILanguegeDTO
    {
        public string Title { get; set; }
        public string OriginalTitle { get; set; }


    }
}
