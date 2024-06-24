using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.DTOs.Product;
using BSG.EasyShop.Application.DTOs.ProductImage;

namespace BSG.EasyShop.Application.DTOs.Brand
{
    public class ProductImageDTO:BaseDTO,IProductImageDTO
    {
        public long ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public string ImagePathOriginalSize { get; set; }
        public string ImagePathNormalSize { get; set; }
        public string ImagePathThumbnailSize { get; set; }
        public string ImagePathFingerSize { get; set; }
        public int ViewOrder { get; set; }
    }
}
