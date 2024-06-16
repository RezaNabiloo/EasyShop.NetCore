using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain.Translate
{
    /// <summary>
    /// Entity for Brand Translation in selected langueges
    /// </summary>
    public class BrandTrn : TranslateEntity
    {
        public long BrandId { get; set; }
        public Brand Brand { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
