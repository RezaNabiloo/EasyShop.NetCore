﻿using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class Brand : BaseDomainEntity
    {

        public string Title { get; set; }        
        public string? ImagePath { get; set; }
        public string Description{ get; set; }
    }
}
