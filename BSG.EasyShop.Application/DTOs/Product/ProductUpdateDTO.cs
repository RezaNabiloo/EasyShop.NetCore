using BSG.EasyShop.Application.DTOs.Brand;
using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.DTOs.ProductGroup;

namespace BSG.EasyShop.Application.DTOs.Product
{
    public class ProductUpdateDTO : BaseDTO, IProductDTO
    {
        public string Title { get; set; }
        public string Model { get; set; }
        public long ProductGroupId { get; set; }
        public ProductGroupDTO ProductGroup { get; set; }
        public long? BrandId { get; set; }
        public ProductImageDTO Brand { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Slug { get; set; }
        public bool OutOfSale { get; set; }
        public bool IsActive { get; set; }
    }
}
