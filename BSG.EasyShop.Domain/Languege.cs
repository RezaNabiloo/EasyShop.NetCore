using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class Languege : BaseEntity
    {   
        public string Title { get; set; }
        public string OriginalTitle{ get; set; }
        public string? ImagePath { get; set; }        
    }
}
