using Microsoft.Extensions.DependencyInjection;

namespace ServiceLayer
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPostsService, PostsService>();
        }
    }
}
