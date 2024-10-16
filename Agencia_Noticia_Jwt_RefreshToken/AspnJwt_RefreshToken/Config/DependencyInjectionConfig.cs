using MvcBlogNoticias.Api.Data;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace BlogNoticias.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            return services;
        }
    }
}
