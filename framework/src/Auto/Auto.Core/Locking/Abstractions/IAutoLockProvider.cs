using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;

namespace Auto.Core.Lock.Abstractions
{
    public interface IAutoLockProvider
    {
        //Task LockAsync(AspectContext context, AspectDelegate next);
        Task LockAsync(Func<Task> func);
    }
}