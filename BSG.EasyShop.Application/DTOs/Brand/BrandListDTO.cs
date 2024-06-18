using BSG.EasyShop.Application.DTOs.Common;

namespace BSG.EasyShop.Application.DTOs.Brand
{
    public class BrandListDTO : BaseDTO
    {
        public string? Title { get; set; }        
        public string? ImagePath { get; set; }

        public string? Descrioption { get; set; }

    }
}
