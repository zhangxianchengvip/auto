using Auto.Core.AutoDependencyInjection;
using Auto.Core.Caching;
using Auto.Core.Caching.Abstractions;
using Auto.Core.Options;
using Auto.Core.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auto.Core
{
    public static class AutoCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoCache();
            services.AddAutoOptions(configuration);
            services.AddAutoServiceRegister();
            return services;
        }

        private static IServiceCollection AddAutoCache(this IServiceCollection services)
        {
            services.AddSingleton<IAutoSerializerProvider, AutoSerializerProvider>();
            services.AddSingleton<IAutoCacheProvider, MemoryCacheProvider>();
            services.AddMemoryCache();
            return services;
        }

        private static IServiceCollection AddAutoOptions(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure(configuration);
        }

        private static IServiceCollection AddAutoServiceRegister(this IServiceCollection services)
        {
            return services.ServiceRegister();
        }
    }
}