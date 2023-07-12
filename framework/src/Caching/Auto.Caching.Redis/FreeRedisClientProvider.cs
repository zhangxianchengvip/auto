using Auto.Caching.Redis.Abstractions;
using Auto.Core.Serialization;
using FreeRedis;
using System;
using System.Threading.Tasks;

namespace Auto.Caching.Redis
{
    public class FreeRedisClientProvider : IAutoRedisProvider
    {
        private readonly IRedisClient _redisClient;
        private readonly IAutoSerializerProvider _serializer;
        public FreeRedisClientProvider(IFreeRedisPersistentConnection connect, IAutoSerializerProvider serializer)
        {
            _redisClient = connect.CreateRedisClient();
            _serializer = serializer;
        }

        public virtual async Task<object> GetAsync(string key, Type type)
        {
            return _serializer.Deserialize(await _redisClient.GetAsync<byte[]>(key), type);
        }

        public virtual async Task SetAsync(string key, object value, Type type, int expiration)
        {
            await _redisClient.SetAsync(key, _serializer.SerializeBytes(value, type));
            await _redisClient.ExpireAsync(key, expiration);
        }
    }
}
