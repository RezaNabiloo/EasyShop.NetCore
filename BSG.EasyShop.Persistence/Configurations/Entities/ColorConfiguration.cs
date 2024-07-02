using BSG.EasyShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSG.EasyShop.Persistence.Configurations.Entities
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(
                new Color { 
                    Id=1,
                    Title="سفید",
                    ColorCode="#FFF"                    
                }
                );
        }
    }
}
