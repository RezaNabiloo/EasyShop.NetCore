using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class Township : BaseDomainEntity
    {

        public string Title { get; set; }        
        public long ProvinceID { get; set; }
        public Province Province { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public bool IsCapital { get; set; }
    }
}
