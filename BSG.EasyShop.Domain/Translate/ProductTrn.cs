using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain.Translate
{
    public class ProductTrn : BaseDomainTranslateEntity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }


        public string Title { get; set; }
        public string Model { get; set; }

        public string ShortDescription { get; set; }
        public string Description { get; set; }

    }
}
