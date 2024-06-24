using BSG.EasyShop.Application.DTOs.Province;

namespace BSG.EasyShop.Application.DTOs.Township
{
    public interface ITownshipDTO
    {
        public string Title { get; set; }
        public long ProvinceId { get; set; }
        public ProvinceDTO Province { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public bool IsCapital { get; set; }
    }
}
