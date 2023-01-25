using Microsoft.Extensions.DependencyInjection;

namespace CachingWithRepositoryPattern.DataAccess;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; set; }
    public static IServiceCollection AddCreateService(this IServiceCollection services)
    {
        services.AddMemoryCache();
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
