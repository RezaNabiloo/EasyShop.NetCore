using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class ProductGroupSize : BaseEntity
    {

        public string Title { get; set; }        
        public long ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string Description { get; set; }
    }
}
