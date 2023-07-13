# Auto Core   (基于AspectCore)

![logo.png](https://github.com/zhangxianchengvip/auto/blob/main/logo/logo.png?raw=true)

#### 介绍
**[AutoCore](https://github.com/zhangxianchengvip/auto)**是基于 .Net Standard 2.1用于简化 [ASP.NET Core](https://learn.microsoft.com/zh-cn/aspnet/core/getting-started/?view=aspnetcore-6.0&tabs=windows)开发，**[AutoCore](https://github.com/zhangxianchengvip/auto)** 在 **[AspectCore](https://github.com/dotnetcore/AspectCore-Framework/blob/master/docs/reflection-extensions.md)** 的基础上进行功能开发，**[AspectCore](https://github.com/dotnetcore/AspectCore-Framework/blob/master/docs/reflection-extensions.md)** 在性能上都比反射有2个数量级的优化，达到了和硬编码调用相同的数量级。

**[AspectCore](https://github.com/dotnetcore/AspectCore-Framework/blob/master/docs/reflection-extensions.md)** 方法调用反射扩展

性能测试:（Reflection为.NET Core提供的反射调用，Reflector为AspectCore.Extension.Reflection调用，Native为硬编码调用

```
 |             Method |        Mean |     Error |    StdDev |    StdErr |            Op/s |
 |------------------- |------------:|----------:|----------:|----------:|----------------:|
 |        Native_Call |   1.0473 ns | 0.0064 ns | 0.0050 ns | 0.0015 ns |   954,874,046.8 |
 |    Reflection_Call |  91.9543 ns | 0.3540 ns | 0.3311 ns | 0.0855 ns |    10,874,961.4 |
 |     Reflector_Call |   7.1544 ns | 0.0628 ns | 0.0587 ns | 0.0152 ns |   139,774,408.3 |
```

#### 快速开始

1. 安装

- [Package Manager](https://www.nuget.org/packages/Auto.Core)

```
Install-Package Auto.Core
```

- [.NET CLI](https://www.nuget.org/packages/Auto.Core)

```
dotnet add package Auto.Core
```

2. 配置 ServiceProviderFactory

```c#
builder.Host.UseServiceProviderFactory(new AutoServiceProviderFactory());
```

3. 注册AutoCore

```c#
builder.Services.AddAutoCore(builder.Configuration);
```

4. AutoOptions (选项)

```C#
//appsettings.json
{
  "Redis": {
    "Host": "localhost",
    "Port": 6379,
    "Password": "zxc123..."
  }
}

//选项类：标记绑定
[AutoOptions(Node ="Redis")]
public class Redis
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Password { get; set; }
}

//构造函数注入
private readonly Redis _redis;
public WeatherForecast(IOptionsSnapshot<Redis> options)
{
     _redis = options.Value;
}

```

5. AutoCache (缓存)

```c#
//方法：标记缓存
[AutoCache]
public virtual async Task<IEnumerable<WeatherForecast>> Get(User user)
{
    var ss = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    }).ToArray();

    return ss;
}
```

6. AutoService(服务注册)

```c#
//接口
public interface IUser
{
    void Get();
}

//实现：标记注册
[AutoService]
public class User : IUser
{
    public void Get()
    {
        Console.WriteLine(1);
    }
}

//构造函数注入
private readonly IUser _user;
public WeatherForecastController(IUser user)
{
    _user = user;
}
```

7. 参数校验

```c#
//参数校验：参数标记校验方法
public WeatherForecast([NotNull] string userName)
{
  string  un = userName;
}
```

#### AutoCache（缓存）

1. redis缓存提供

```
Install-Package Auto.Core.Redis
```

2. [appsettings.json]()

```json
{
  "RedisOptions": {
    "Host": "127.0.0.1",
    "Port": 6379,
    "Database": 0
  }
}
```



#### AutoValidation（参数校验）

1. 字符串最大长度	[MaxLengthAttribute]

2. 字符串最小长度    [MinLengthAttribute]
3. 字符串不能为空或Null    [NotNullOrEmptyAttribute]

4. 字符串不能为Null或空格    [NotNullOrWhiteSpaceAttribute]
5. 对象不能为Null    [NotNullAttribute]

6. 范围    [RangeAttribute]

   

#### 常见问题

功能无法正常使用

1. 检查方法设置为 virtual

```C#
[HttpPost(Name = "GetWeatherForecast")]
[AutoCache]
public virtual async Task<IEnumerable<WeatherForecast>> Get(User user)
{
    var ss = Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();

       return ss;
    }
}
```

注意：控制器中的方法需要注册为服务后才可以使用

```C#
builder.Services.AddControllers().AddControllersAsServices();
```

2. 检查是否注册AutoCore

```
builder.Services.AddAutoCore(builder.Configuration);
```

3. 检查是否配置ServiceProviderFactory

```
builder.Host.UseServiceProviderFactory(new AutoServiceProviderFactory());
```

