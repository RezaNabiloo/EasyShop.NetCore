using AutoMapper;
using BSG.EasyShop.Application.DTOs.Country;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Profiles
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();            
            CreateMap<Country, CountryCreateDTO>().ReverseMap();
            CreateMap<Country, CountryUpdateDTO>().ReverseMap();
        }
    }
}
