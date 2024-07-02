using BSG.EasyShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Persistence.Configurations.Entities
{
    public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.HasData(
                new ProductGroup{
                    Id= 1,
                    Title= "کالای دیجیتال"
                },
                new ProductGroup { 
                    Id= 2,  
                    Title= "گوشی موبایل",
                    ParentProductGroupId= 1,
                }
                );
        }
    }
}
