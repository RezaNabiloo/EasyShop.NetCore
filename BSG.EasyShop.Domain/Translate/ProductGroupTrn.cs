using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain.Translate
{
    public class ProductGroupTrn : TranslateEntity
    {
        public long ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public string Title { get; set; }

    }
}
