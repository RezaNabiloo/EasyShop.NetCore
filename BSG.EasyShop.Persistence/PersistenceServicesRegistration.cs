using BSG.EasyShop.Application.Contracts.Persistance;
using BSG.EasyShop.Application.Contracts.Persistance.Common;
using BSG.EasyShop.Persistence.Repositories;
using BSG.EasyShop.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSG.EasyShop.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices (this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<EasyShopDbContext>(options => {
                //options.UseSqlServer("connection string manualy"); can set connection string manualy
                options.UseSqlServer(configuration.GetConnectionString("EasyShopConnectionString"));
            });


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IBrandRepository), typeof(BrandRepository));
            services.AddScoped(typeof(IProductGroupRepository), typeof(ProductGroupRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));

            // TODO how to add all scoped with loop ????

            return services;

        }
    }
}
