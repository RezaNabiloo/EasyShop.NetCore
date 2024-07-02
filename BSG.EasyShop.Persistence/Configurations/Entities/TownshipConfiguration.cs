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
    public class TownshipConfiguration : IEntityTypeConfiguration<Township>
    {
        public void Configure(EntityTypeBuilder<Township> builder)
        {
            builder.HasData(
                new Township { 
                    Id = 1,
                    Title = "Title",
                    ProvinceId=1,                    
                    Lat= 35.7219,
                    Lng= 51.3347,
                    IsCapital = true
                }
                );
        }
    }
}
