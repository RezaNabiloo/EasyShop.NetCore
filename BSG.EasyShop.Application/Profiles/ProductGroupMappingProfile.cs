using AutoMapper;
using BSG.EasyShop.Application.DTOs.ProductGroup;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Profiles
{
    public class ProductGroupMappingProfile:Profile
    {
        public ProductGroupMappingProfile()
        {
            CreateMap<ProductGroup, ProductGroupDTO>().ReverseMap();
        }
    }
}
