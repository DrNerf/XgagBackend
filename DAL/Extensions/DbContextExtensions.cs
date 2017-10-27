using System;
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

            RegisterRepositories(services);
        }

        private static void RegisterRepositories(
            IServiceCollection services)
        {
            services.AddTransient<IRepository<Post>, Repository<Post>>();
            services.AddTransient<IRepository<AspNetUser>, Repository<AspNetUser>>();
        }
    }
}
