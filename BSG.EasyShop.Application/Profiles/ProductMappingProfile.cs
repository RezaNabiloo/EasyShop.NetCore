using AutoMapper;
using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.DTOs.ProductGroup;
using BSG.EasyShop.Domain;

namespace BSG.EasyShop.Application.Profiles
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            

            CreateMap<Product,IProductDTO>().ReverseMap();
            CreateMap<Product, ProductListDTO>().ReverseMap();
            
        }
    } 
}
