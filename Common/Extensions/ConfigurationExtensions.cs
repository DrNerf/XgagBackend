using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class ConfigurationExtensions
    {
        public static void AddCommonConfigurationOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ServersAddressesModel>(configuration);
        }

        public static void AddActionFilters(this IServiceCollection services)
        {
            services.AddTransient(typeof(AuthorizeAttribute));
        }
    }
}
