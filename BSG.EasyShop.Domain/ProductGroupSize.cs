using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class ProductGroupSize : BaseDomainEntity
    {

        public string Title { get; set; }        
        public long ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string Description { get; set; }
    }
}
