﻿using BSG.EasyShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSG.EasyShop.Persistence.Configurations.Entities
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand { 
                    Id=1,
                    FaTitle="اپل",
                    EnTitle="Apple"
                },
                new Brand { 
                    Id=2,
                    FaTitle="سامسونگ",
                    EnTitle="Samsung"
                }
                );
        }
    }
}
