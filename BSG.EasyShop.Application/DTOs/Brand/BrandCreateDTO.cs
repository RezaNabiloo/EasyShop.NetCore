﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Application.DTOs.Brand
{
    public class BrandCreateDTO:IBrandDTO
    {
        public string Title { get; set; }        

        public string ImagePath { get; set; }

        public string Description { get; set; }
    }
}
