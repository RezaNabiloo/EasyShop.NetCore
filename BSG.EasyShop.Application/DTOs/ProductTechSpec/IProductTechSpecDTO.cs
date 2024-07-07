using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.DTOs.ProductGroupTechSpec;

namespace BSG.EasyShop.Application.DTOs.ProductTechSpec
{
    public interface IProductTechSpecDTO
    {
        public long ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public long ProductGroupTechSpecId { get; set; }
        public ProductGroupTechSpecDTO ProductGroupTechSpec { get; set; }
        public string TechSpechValue { get; set; }
        
    }
}
