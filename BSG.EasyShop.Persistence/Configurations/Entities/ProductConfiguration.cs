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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Has not seed data 
            // if i want to set seed data, can add here 
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Title = "گوشی موبایل",
                    ProductGroupId = 2,
                    BrandId = 1,
                    Price = 1000,
                    Discount = 0,
                    ShortDescription = "",
                    Description = "",
                    Keywords = "",
                    Slug = "",
                    OutOfSale = false,
                    IsActive = true,
                    IsConfirmed = true
                }
                );

        }
    }
}
