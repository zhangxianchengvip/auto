using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Core.Caching.Abstractions
{
    public interface IAutoCacheProvider
    {
        public Task<object> GetAsync(string key,Type type);
        public Task SetAsync(string key, object value,Type type,int expiration);
    }
}
