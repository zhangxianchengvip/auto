using Microsoft.Extensions.DependencyInjection;

namespace Auto.EntityFrameworkCore;

public static class EntityFrameworkCoreServiceCollectionExtension
{
    public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services)
    {
        return services;
    }
}