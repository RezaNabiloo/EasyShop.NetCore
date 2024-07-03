using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class Languege : BaseDomainEntity
    {   
        public string Title { get; set; }
        public string OriginalTitle{ get; set; }
        public string Abbreviation { get; set; }
        public bool IsDefault { get; set; }
        public string? ImagePath { get; set; }        
    }
}
