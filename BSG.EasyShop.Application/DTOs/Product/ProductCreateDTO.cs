using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.DTOs.ProductGroup;

namespace BSG.EasyShop.Application.DTOs.Product
{
    public class ProductCreateDTO:IProductDTO 
    {
        public string Title { get; set; }
        public string Model { get; set; }

        public long ProductGroupId { get; set; }
        public ProductGroupDTO ProductGroup { get; set; }

        public long? BrandId { get; set; }
        public BrandDTO Brand { get; set; }
    }
}
