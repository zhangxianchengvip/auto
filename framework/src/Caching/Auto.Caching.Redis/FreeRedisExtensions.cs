using Auto.Caching.Redis.Abstractions;
using Auto.Core.Caching.Abstractions;
using FreeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Caching.Redis
{
    public static class FreeRedisExtensions
    {
        public static IServiceCollection AddAutoRedis(this IServiceCollection services )
        {
            services.AddSingleton<IFreeRedisPersistentConnection, FreeRedisConnection>();
            services.AddSingleton<IAutoRedisProvider, FreeRedisClientProvider>();
            services.AddSingleton<IAutoCacheProvider, FreeRedisClientProvider>();
            return services;
        }
    }
}
