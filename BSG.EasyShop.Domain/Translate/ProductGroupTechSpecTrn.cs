using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain.Translate
{
    public class ProductGroupTechSpecTrn : TranslateEntity
    {
        public long ProductGroupTechSpecId { get; set; }
        public ProductGroupTechSpec ProductGroupTechSpec { get; set; }

        public string Title { get; set; }

    }
}
