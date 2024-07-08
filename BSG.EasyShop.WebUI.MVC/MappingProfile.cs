using AutoMapper;
using BSG.EasyShop.WebUI.MVC.Models;
using BSG.EasyShop.WebUI.MVC.Services.Base;

namespace BSG.EasyShop.WebUI.MVC
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandCreateDTO, BrandCreateVM>().ReverseMap();
            CreateMap<BrandDTO, BrandVM>().ReverseMap();
            CreateMap<BrandUpdateDTO, BrandVM>().ReverseMap();
            CreateMap<BrandDTO, BrandVM>().ReverseMap();

        }
    }
}
