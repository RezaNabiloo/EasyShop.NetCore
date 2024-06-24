using BSG.EasyShop.Application.DTOs.ProductGroup;

namespace BSG.EasyShop.Application.DTOs.ProductGroupTechSpec
{
    public interface IProductGroupTechSpecDTO
    {
        public long ProductGroupId { get; set; }
        public ProductGroupDTO ProductGroup { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public string DataType { get; set; }
        public int ViewOrder { get; set; }
    }
}
