using FreeRedis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Caching.Redis
{
    public interface IFreeRedisPersistentConnection: IDisposable
    {
        public IRedisClient CreateRedisClient();
    }
}
