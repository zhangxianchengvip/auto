using Microsoft.Extensions.DependencyInjection;

namespace Auto.Domain;

public static class DomainServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}