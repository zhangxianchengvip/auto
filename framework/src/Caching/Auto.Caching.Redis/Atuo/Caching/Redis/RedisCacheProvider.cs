using Auto.Core.Caching.Abstractions;
using Auto.Core.Serialization;
using FreeRedis;
using System;
using System.Threading.Tasks;

namespace Auto.Caching.Redis.Atuo.Caching.Redis
{
    public class RedisCacheProvider : IAutoCacheProvider
    {
        private readonly IRedisClient _redisClient;
        private readonly IAutoSerializerProvider _serializer;
        public RedisCacheProvider(IAutoSerializerProvider serializer, IRedisClient redisClient)
        {
            _serializer = serializer;
            _redisClient = redisClient;
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
