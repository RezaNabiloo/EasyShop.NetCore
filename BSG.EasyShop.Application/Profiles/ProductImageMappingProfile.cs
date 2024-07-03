using AutoMapper;
using BSG.EasyShop.Application.DTOs.ProductImage;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Profiles
{
    public class ProductImageMappingProfile:Profile
    {
        public ProductImageMappingProfile()
        {
            CreateMap<ProductImage, ProductImageDTO>().ReverseMap();
        }
    }
}
