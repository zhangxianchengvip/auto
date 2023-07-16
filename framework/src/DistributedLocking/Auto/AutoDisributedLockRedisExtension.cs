using Auto.Core.Caching.Abstractions;
using Auto.Core.Lock.Abstractions;
using Auto.DistributedLock.Redis.Auto.DistributeLock.Redis;
using FreeRedis.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.DistributedLock.Redis;
public static class AutoDisributedLockRedisExtension
{
    public static IServiceCollection AddAutoDisributedLockRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFreeRedis(configuration);
        services.AddSingleton<IAutoLockProvider, AutoDistributedLockRedisProvider>();
        return services;
    }
}
