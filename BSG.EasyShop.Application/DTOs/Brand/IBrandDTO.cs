using BSG.EasyShop.Application.DTOs.Common;

namespace BSG.EasyShop.Application.DTOs.Brand
{
    public interface IBrandDTO
    {
        public string Title { get; set; }        
        public string ImagePath { get; set; }
        public string Description { get; set; }

    }
}
