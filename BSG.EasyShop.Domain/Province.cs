﻿using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class Province : BaseDomainEntity
    {

        public string Title { get; set; }        
        public long CountryId { get; set; }
        public Country Country{ get; set; }

    }
}
