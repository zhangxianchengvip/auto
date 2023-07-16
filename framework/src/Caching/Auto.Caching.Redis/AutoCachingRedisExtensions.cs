using Auto.Caching.Redis.Atuo.Caching.Redis;
using Auto.Core.Caching.Abstractions;
using FreeRedis.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auto.Caching.Redis
{
    public static class AutoCachingRedisExtensions
    {
        public static IServiceCollection AddAutoRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFreeRedis(configuration);
            services.AddSingleton<IAutoCacheProvider, RedisCacheProvider>();
            return services;
        }
    }
}
