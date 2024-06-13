using BSG.EasyShop.Identity.Configurations;
using BSG.EasyShop.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BSG.EasyShop.Identity
{
    public class EasyShopIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        public EasyShopIdentityDbContext(DbContextOptions<EasyShopIdentityDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
