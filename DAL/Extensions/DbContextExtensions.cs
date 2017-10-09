using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DbContextExtensions
    {
        public static void AddXgagDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<XgagDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("XgagDbContext")));
        }
    }
}
