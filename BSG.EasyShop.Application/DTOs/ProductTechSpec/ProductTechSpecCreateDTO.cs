using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.DTOs.Product;

namespace BSG.EasyShop.Application.DTOs.ProductTechSpec
{
    public class ProductTechSpecCreateDTO : IProductTechSpecDTO
    {
        public long ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public long ProductGroupTechSpecId { get; set; }
        public ProductGroupTechSpecDTO ProductGroupTechSpec { get; set; }
        public string TechSpechValue { get; set; }
    }
}
