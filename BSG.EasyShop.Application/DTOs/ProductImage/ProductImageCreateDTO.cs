using BSG.EasyShop.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.DTOs.ProductImage
{
    public class ProductImageCreateDTO : IProductImageDTO
    {
        public long ProductId { get; set; }        
        public string ImagePathOriginalSize { get; set; }
        public string ImagePathNormalSize { get; set; }
        public string ImagePathThumbnailSize { get; set; }
        public string ImagePathFingerSize { get; set; }
        public int ViewOrder { get; set; }
    }
}
