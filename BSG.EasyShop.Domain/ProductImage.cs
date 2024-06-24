using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class ProductImage : BaseDomainEntity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public string ImagePathOriginalSize { get; set; }
        public string ImagePathNormalSize { get; set; }
        public string ImagePathThumbnailSize { get; set; }
        public string ImagePathFingerSize { get; set; }
        public int ViewOrder { get; set; }
    }
}
