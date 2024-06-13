using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSG.EasyShop.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "5bed52ad-d5e0-4c1b-b440-a19ea0a4a19a",
                    RoleId = "44fceb3a-9f1e-437c-a644-d845dd2245b3"
                },
                new IdentityUserRole<string>
                {
                    UserId = "b85ffbe8-f848-4913-9480-f3ea8a19f4be",
                    RoleId = "ba9f5318-979a-409f-8564-ed5cdf5978d8"
                }
                );

        }
    }
}
