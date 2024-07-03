﻿namespace BSG.EasyShop.Application.DTOs.ProductImage
{
    public interface IProductImageDTO
    {
        public long ProductId { get; set; }        
        public string ImagePathOriginalSize { get; set; }
        public string ImagePathNormalSize { get; set; }
        public string ImagePathThumbnailSize { get; set; }
        public string ImagePathFingerSize { get; set; }
        public int ViewOrder { get; set; }

    }
}
