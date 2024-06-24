using BSG.EasyShop.Application.DTOs.Common;

namespace BSG.EasyShop.Application.DTOs.Country
{
    public class CountryDTO:BaseDTO, ICountryDTO
    {
        public string Title { get; set; }
    }
}
