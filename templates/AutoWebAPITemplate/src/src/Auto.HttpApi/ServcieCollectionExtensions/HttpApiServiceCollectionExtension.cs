using Auto.Application;
using Auto.EntityFrameworkCore;

namespace Auto.HttpApi;

public static class HttpApiServiceCollectionExtension
{
    public static IServiceCollection AddHttpApi(this IServiceCollection services)
    {
        services.AddApplication();
        services.AddEntityFrameworkCore();
        return services;
    }
}