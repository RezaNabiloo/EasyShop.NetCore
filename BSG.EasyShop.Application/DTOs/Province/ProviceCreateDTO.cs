using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.DTOs.Country;
using BSG.EasyShop.Application.DTOs.Province;

namespace BSG.EasyShop.Application.DTOs.Pvince
{
    public class ProvinceCreateDTO:BaseDTO,IProvinceDTO
    {
        public string Title { get; set; }        

        public long CountryId { get; set; }
        public CountryDTO Country { get; set; }
        
    }
}
