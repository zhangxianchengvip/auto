using System;
using System.Threading.Tasks;
using Auto.Core.Caching.Abstractions;
using Auto.Core.Serialization;
using Microsoft.Extensions.Caching.Memory;

namespace Auto.Core.Caching
{
    /// <summary>
    /// Aop 内存缓存实现
    /// </summary>
    public class MemoryCacheProvider : IAutoCacheProvider
    {
        private readonly IMemoryCache _cache;
        private readonly IAutoSerializerProvider _serializer;

        public MemoryCacheProvider(IMemoryCache cache, IAutoSerializerProvider serializer)
        {
            _cache = cache;
            _serializer = serializer;
        }

        public Task<object> GetAsync(string key, Type type)
        {
            return Task.FromResult(_cache.Get(key) ?? null);
        }

        public Task SetAsync(string key, object value, Type type, int expiration)
        {
            _cache.Set(key, _serializer.Clone(value, type), new DateTimeOffset(DateTime.Now.AddSeconds(expiration)));
            return Task.CompletedTask;
        }
    }
}