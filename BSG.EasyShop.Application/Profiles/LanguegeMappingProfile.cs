using AutoMapper;
using BSG.EasyShop.Application.DTOs.Languege;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Profiles
{
    public class LanguegeMappingProfile : Profile
    {
        public LanguegeMappingProfile()
        {
            CreateMap<Languege, LanguegeDTO>().ReverseMap();            
            CreateMap<Languege, LanguegeCreateDTO>().ReverseMap();
            CreateMap<Languege, LanguegeUpdateDTO>().ReverseMap();
        }
    }
}
