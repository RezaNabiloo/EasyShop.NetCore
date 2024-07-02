using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class ProductTechSpec : BaseDomainEntity
    {
        public long ProductId { get; set; }
        public Product Product{ get; set; }
        public long ProductGroupTechSpecId { get; set; }
        public ProductGroupTechSpec ProductGroupTechSpec { get; set; }
        public string TechSpecValue { get; set; }
    }
}
