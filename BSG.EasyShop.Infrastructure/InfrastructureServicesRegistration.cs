using BSG.EasyShop.Application.Contracts.Infrastructure.Email;
using BSG.EasyShop.Application.Models.Email;
using BSG.EasyShop.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSG.EasyShop.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
           IConfiguration configuration)
        {

            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));

            services.AddTransient<IEmailSender,EmailSender>();

            return services;

        }
    }
}
