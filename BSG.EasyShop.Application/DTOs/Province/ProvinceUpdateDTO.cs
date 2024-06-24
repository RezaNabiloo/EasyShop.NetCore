using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.DTOs.Country;

namespace BSG.EasyShop.Application.DTOs.Province
{
    public class ProvinceUpdateDTO : BaseDTO, IProvinceDTO
    {
        public string Title { get; set; }        
        public long CountryId { get; set; }
        public CountryDTO Country { get; set; }

    }
}
