using BSG.EasyShop.Application.DTOs.Common;

namespace BSG.EasyShop.Application.DTOs.ProductGroup
{
    public interface IProductGroupDTO 
    {
        public string Title { get; set; }

        public long? ParentProductGroupId { get; set; }

        public ProductGroupDTO ParentProductGroup { get; set; }

        public string ImagePath { get; set; }
    }
}
