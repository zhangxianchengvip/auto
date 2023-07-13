using AspectCore.DependencyInjection;
using AspectCore.DynamicProxy;
using Auto.Core.AspectExtionsions;
using Auto.Core.Caching.Abstractions;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Auto.Core.Caching
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AutoCacheAttribute : AbstractInterceptorAttribute
    {
        /// <summary>
        /// 注入缓存实例
        /// </summary>
        [FromServiceContext]
        private IAutoCacheProvider Provider { get; set; }

        /// <summary>
        /// 获取Task.FromResult<T>();
        /// </summary>
        private static readonly MethodInfo TaskResultMethod = typeof(Task)
            .GetMethods()
            .FirstOrDefault
            (
                p => p.Name == "FromResult" && p.ContainsGenericParameters
            );

        /// <summary>
        /// 缓存Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 缓存过期时间（分钟）
        /// </summary>
        public int Expiration { get; set; } = 300;

        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var returnType = context.GetReturnType();
            var cacheValue = await CacheValueProvider(context, returnType);
            if (cacheValue != null) return;
            await next.Invoke(context);
            var returnValue = await context.GetReturnValue();
            await Provider.SetAsync(Key ?? context.GetCacheKey(), returnValue, returnType, Expiration);
        }

        private async Task<object> CacheValueProvider(AspectContext context, Type returnType)
        {
            var cacheValue = await Provider.GetAsync(Key ?? context.GetCacheKey(), returnType);
            context.ReturnValue = context.IsAsync()
                ? TaskResultMethod.MakeGenericMethod(returnType).Invoke(null, new object[] { cacheValue })
                : cacheValue;
            return cacheValue;
        }
    }
}