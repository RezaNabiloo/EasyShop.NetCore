using BSG.EasyShop.Identity.Models;
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
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "5bed52ad-d5e0-4c1b-b440-a19ea0a4a19a",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin",
                    FirstName = "System",
                    LastName = "Administrator",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true

                },
                new ApplicationUser
                {
                    Id = "b85ffbe8-f848-4913-9480-f3ea8a19f4be",
                    Email = "guest@localhost.com",
                    NormalizedEmail = "GUEST@LOCALHOST.COM",
                    UserName = "guest",
                    FirstName = "Guest",
                    LastName = "User",
                    NormalizedUserName = "GUEST",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true

                }
                );
        }
    }
}
