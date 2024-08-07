﻿using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class Color : BaseDomainEntity
    {

        public string Title { get; set; }        
        public string ColorCode { get; set; }
        public string? Description{ get; set; }
    }
}
