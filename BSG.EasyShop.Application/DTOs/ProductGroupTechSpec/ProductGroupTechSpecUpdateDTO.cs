﻿using BSG.EasyShop.Application.DTOs.Common;
using BSG.EasyShop.Application.DTOs.ProductGroup;

namespace BSG.EasyShop.Application.DTOs.ProductGroupTechSpec
{
    public class ProductGroupTechSpecUpdateDTO :BaseDTO, IProductGroupTechSpecDTO
    {
        public string Title { get; set; }
        public long ProductGroupId { get; set; }
        public ProductGroupDTO ProductGroup { get; set; }        
        public string? ImagePath { get; set; }
        public string DataType { get; set; }
        public int ViewOrder { get; set; }
    }
}
