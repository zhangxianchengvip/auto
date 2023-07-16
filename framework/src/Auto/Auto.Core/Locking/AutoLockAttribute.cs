using System;
using System.Threading.Tasks;
using AspectCore.DependencyInjection;
using AspectCore.DynamicProxy;
using Auto.Core.Lock.Abstractions;

namespace Auto.Core.Lock
{
    public class AutoLockAttribute : AbstractInterceptorAttribute
    {
        /// <summary>
        /// 注入缓存实例
        /// </summary>
        [FromServiceContext]
        private IAutoLockProvider AutoLock { get; set; }

        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            // await AutoLock.LockAsync(context, next);
            await AutoLock.LockAsync(() => next(context));
        }
    }
}