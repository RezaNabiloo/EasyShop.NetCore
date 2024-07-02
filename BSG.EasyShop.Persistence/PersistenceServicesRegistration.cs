using BSG.EasyShop.Application.Contracts.Persistence;
using BSG.EasyShop.Application.Contracts.Persistence.Common;
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
            
            services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));            
            services.AddScoped(typeof(IProvinceRepository), typeof(ProvinceRepository));
            services.AddScoped(typeof(ITownshipRepository), typeof(TownshipRepository));
            //services.AddScoped(typeof(ILanguegeRepository), typeof(LanguegeRepository));
            //services.AddScoped(typeof(IColorRepository), typeof(ColorRepository));            
            //services.AddScoped(typeof(IBrandRepository), typeof(BrandRepository));
            //services.AddScoped(typeof(IProductGroupRepository), typeof(ProductGroupRepository));
            //services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            //services.AddScoped(typeof(IProductImageRepository), typeof(ProductImageRepository));
            //services.AddScoped(typeof(IProductTechSpecRepository), typeof(ProductTechSpecRepository));
            //services.AddScoped(typeof(IProductGroupSizeRepository), typeof(ProductGroupSizeRepository));
            //services.AddScoped(typeof(IProductGroupTechSpecRepository), typeof(ProductGroupTechSpecRepository));

            // TODO how to add all scoped with loop ????

            return services;

        }
    }
}
