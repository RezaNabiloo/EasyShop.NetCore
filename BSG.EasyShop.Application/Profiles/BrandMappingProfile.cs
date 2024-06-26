using AutoMapper;
using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Profiles
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();            
            CreateMap<Brand, BrandCreateDTO>().ReverseMap();
            CreateMap<Brand, BrandUpdateDTO>().ReverseMap();
        }
    }
}
