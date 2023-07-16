using System;
using System.Threading;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using Auto.Core.Lock.Abstractions;
using Nito.AsyncEx;

namespace Auto.Core.Lock
{
    public class ProcessLockProvider : IAutoLockProvider
    {
        private readonly AsyncLock _mutex = new AsyncLock();

        // public async Task LockAsync(AspectContext context, AspectDelegate next)
        // {
        //     using (await _mutex.LockAsync(new CancellationTokenSource(TimeSpan.FromSeconds(2)).Token))
        //     {
        //         await next.Invoke(context);
        //     }
        // }

        public async Task LockAsync(Func<Task> func)
        {
            using (await _mutex.LockAsync(new CancellationTokenSource(TimeSpan.FromSeconds(2)).Token))
            {
                await func();
            }
        }
    }
}