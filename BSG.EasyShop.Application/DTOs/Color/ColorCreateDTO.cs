using BSG.EasyShop.Application.DTOs.Common;

namespace BSG.EasyShop.Application.DTOs.Color
{
    public class ColorCreateDTO:IColorDTO
    {
        public string Title { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
    }
}
