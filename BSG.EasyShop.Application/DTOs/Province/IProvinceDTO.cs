using BSG.EasyShop.Application.DTOs.Country;

namespace BSG.EasyShop.Application.DTOs.Province
{
    public interface IProvinceDTO
    {
        public string Title { get; set; }
        public long CountryId { get; set; }
        public CountryDTO Country { get; set; }
    }
}
