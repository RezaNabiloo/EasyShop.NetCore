using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class Brand : BaseEntity
    {

        public string FaTitle { get; set; }
        public string EnTitle { get; set; }
        public string? ImagePath { get; set; }
    }
}
