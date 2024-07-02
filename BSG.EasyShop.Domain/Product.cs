using BSG.EasyShop.Domain.Common;

namespace BSG.EasyShop.Domain
{
    public class Product : BaseDomainEntity
    {
        public string Title { get; set; }
        public string? Model { get; set; }
        public long ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public long? BrandId { get; set; }
        public Brand Brand { get; set; }

        public long Price { get; set; }

        public long Discount { get; set; }

        public string? ShortDescription { get; set; }
        public string? Description { get; set; }

        public string? Keywords { get; set; }
        public string? Slug { get; set; }
        public bool OutOfSale { get; set; }
        public bool IsActive { get; set; }
        public bool IsConfirmed { get; set; }

    }
}
