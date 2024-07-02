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
    public class ProductTechSpecConfiguration : IEntityTypeConfiguration<ProductTechSpec>
    {
        public void Configure(EntityTypeBuilder<ProductTechSpec> builder)
        {
            // Has not seed data 
            // if i want to set seed data, can add here 
            builder.HasData(
                new ProductTechSpec { 
                    Id=1,
                    ProductId=1,
                    ProductGroupTechSpecId=1,
                    TechSpecValue="100",
                }
                );
            
        }
    }
}
