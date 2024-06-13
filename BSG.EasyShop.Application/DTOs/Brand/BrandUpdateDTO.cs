﻿using BSG.EasyShop.Application.DTOs.Common;

namespace BSG.EasyShop.Application.DTOs.Brand
{
    public class BrandUpdateDTO:BaseDTO,IBrandDTO
    {
        public string FaTitle { get; set; }
        public string EnTitle { get; set; }
        public string ImagePath { get; set; }


    }
}
