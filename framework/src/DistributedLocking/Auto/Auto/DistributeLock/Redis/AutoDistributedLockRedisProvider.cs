using AspectCore.DynamicProxy;
using Auto.Core.Lock.Abstractions;
using FreeRedis;

namespace Auto.DistributedLock.Redis.Auto.DistributeLock.Redis;

public class AutoDistributedLockRedisProvider : IAutoLockProvider
{
    private static readonly string _distributedLockKey = "DISTRIBUTEDLOCKKEY";

    private readonly IRedisClient _client;

    public AutoDistributedLockRedisProvider(IRedisClient client)
    {
        _client = client;
    }

    public async Task LockAsync(Func<Task> func)
    {
        var lockObj = _client.Lock(_distributedLockKey, 1);

        if (lockObj != null)
        {
            await func();
            lockObj.Unlock(); // 解锁
        }
    }
}