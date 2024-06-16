using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class ProductGroupTechSpec : BaseEntity
    {

        public long ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string Title { get; set; }        
        public string? ImagePath { get; set; }
        public string DataType{ get; set; }
        public int ViewOrder { get; set; }
    }
}
