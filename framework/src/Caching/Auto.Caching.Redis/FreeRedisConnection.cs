using FreeRedis;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Caching.Redis
{
    public class FreeRedisConnection : IFreeRedisPersistentConnection
    {
        private readonly FreeRedisOptions _options;

        public FreeRedisConnection(IOptionsSnapshot<FreeRedisOptions> options)
        {
            _options = options.Value;
        }

        public IRedisClient CreateRedisClient()
        {
            return new RedisClient($"{_options.Host}:{_options.Port},defaultDatabase={_options.Database}");
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
