using BSG.EasyShop.Domain;
using BSG.EasyShop.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BSG.EasyShop.Persistence
{
    public class EasyShopDbContext:DbContext
    {
     
        public EasyShopDbContext(DbContextOptions<EasyShopDbContext> options)
            :base(options)
        {

            
        }

        DbSet<Country> Countries { get; set; }
        DbSet<Province> Provinces { get; set; }
        DbSet<Township> Townships { get; set; }
        DbSet<Languege> Langueges { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<ProductGroup> ProductGroups { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<ProductGroupSize> ProductGroupSizes { get; set; }
        DbSet<ProductGroupTechSpec> ProductGroupTechSpecs { get; set; }
        DbSet<ProductTechSpec> ProductTechSpecs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EasyShopDbContext).Assembly);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastUpdateTime = DateTime.Now;

                if (entry.State==EntityState.Added)
                {
                    entry.Entity.CreateTime = DateTime.Now;
                }
            }            

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastUpdateTime = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateTime = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
