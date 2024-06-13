using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class ProductGroup:BaseEntity
    {        
        public string Title { get; set; }

        public long? ParentProductGroupId { get; set; }

        public  ProductGroup ParentProductGroup { get; set; }

        public string? Slug { get; set; }

        public string? ImagePath { get; set; }

    }
}
