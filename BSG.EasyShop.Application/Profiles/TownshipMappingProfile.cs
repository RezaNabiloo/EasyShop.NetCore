using AutoMapper;
using BSG.EasyShop.Application.DTOs.Township;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Profiles
{
    public class TownshipMappingProfile : Profile
    {
        public TownshipMappingProfile()
        {
            CreateMap<Township, TownshipDTO>().ReverseMap();            
            CreateMap<Township, TownshipCreateDTO>().ReverseMap();
            CreateMap<Township, TownshipUpdateDTO>().ReverseMap();
        }
    }
}
