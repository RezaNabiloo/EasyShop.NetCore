using AutoMapper;
using BSG.EasyShop.Application.DTOs.Province;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Profiles
{
    public class ProvinceMappingProfile : Profile
    {
        public ProvinceMappingProfile()
        {
            CreateMap<Province, ProvinceDTO>().ReverseMap();            
            CreateMap<Province, ProvinceCreateDTO>().ReverseMap();
            CreateMap<Province, ProvinceUpdateDTO>().ReverseMap();
        }
    }
}
