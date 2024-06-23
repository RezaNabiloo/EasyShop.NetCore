using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class ProductImage : BaseDomainEntity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlNormalSize { get; set; }
        public string ImageUrlThumbnailSize { get; set; }
        public string ImageUrlFingerSize { get; set; }
        public int ViewOrder { get; set; }
    }
}
