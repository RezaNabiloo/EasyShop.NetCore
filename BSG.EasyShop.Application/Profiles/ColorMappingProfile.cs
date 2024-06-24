using AutoMapper;
using BSG.EasyShop.Application.DTOs.Color;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Profiles
{
    public class ColorMappingProfile : Profile
    {
        public ColorMappingProfile()
        {
            CreateMap<Color, ColorDTO>().ReverseMap();
            CreateMap<Color, ColorListDTO>().ReverseMap();            
        }
    }
}
