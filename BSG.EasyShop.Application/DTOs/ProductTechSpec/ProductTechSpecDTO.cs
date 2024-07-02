using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.DTOs.ProductTechSpec;

namespace BSG.EasyShop.Application.DTOs.Brand
{
    public class ProductTechSpecDTO : BaseDTO, IProductTechSpecDTO
    {
        public long ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public long ProductGroupTechSpecId { get; set; }
        public ProductGroupTechSpecDTO ProductGroupTechSpec { get; set; }
        public string TechSpechValue { get; set; }
    }
}
