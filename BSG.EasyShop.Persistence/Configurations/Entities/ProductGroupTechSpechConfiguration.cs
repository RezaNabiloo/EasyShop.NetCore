using BSG.EasyShop.Domain;
using BSG.EasyShop.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSG.EasyShop.Persistence.Configurations.Entities
{
    public class ProductGroupTechSpecConfiguration : IEntityTypeConfiguration<ProductGroupTechSpec>
    {
        public void Configure(EntityTypeBuilder<ProductGroupTechSpec> builder)
        {
            builder.HasData(
                new ProductGroupTechSpec
                {
                    Id = 1,
                    ProductGroupId = 2,
                    Title = "وزن",
                    DataType = DataType.String,
                    ViewOrder = 1
                }
                );
        }
    }
}
