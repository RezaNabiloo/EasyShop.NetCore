using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSG.EasyShop.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                  new IdentityRole
                  {
                      Id = "44fceb3a-9f1e-437c-a644-d845dd2245b3",
                      Name = "Administrator",
                      NormalizedName = "ADMINISTRATOR",
                  },
                new IdentityRole
                {
                    Id = "ba9f5318-979a-409f-8564-ed5cdf5978d8",
                    Name = "Member",
                    NormalizedName = "MEMBER",
                }

                );
        }
    }
}
