using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BSG.EasyShop.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            //   
            //services.AddAutoMapper(typeof(MappingProfile));


            // Add all mapper profiles automatically from assembly
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly);
            });
        }
    }
}
