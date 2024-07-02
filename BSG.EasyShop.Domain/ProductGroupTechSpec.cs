using BSG.EasyShop.Domain.Common;
using BSG.EasyShop.Domain.Enum;

namespace BSG.EasyShop.Domain
{
    public class ProductGroupTechSpec : BaseDomainEntity
    {

        public long ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string Title { get; set; }        
        public string? ImagePath { get; set; }
        public DataType DataType{ get; set; }
        public int ViewOrder { get; set; }
    }
}
