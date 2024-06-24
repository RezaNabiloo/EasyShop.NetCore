using BSG.EasyShop.Application.DTOs.ProductGroup;

namespace BSG.EasyShop.Application.DTOs.ProductGroupSize
{
    public class ProductGroupSizeCreateDTO : IProductGroupSizeDTO
    {
        public string Title { get; set; }
        public long ProductGroupId { get; set; }
        public ProductGroupDTO ProductGroup { get; set; }
        public string Description { get; set; }
    }
}
