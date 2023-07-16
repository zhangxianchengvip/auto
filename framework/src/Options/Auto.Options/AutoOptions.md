# Auto.Options

![logo.png](https://github.com/zhangxianchengvip/auto/blob/main/logo/logo.png?raw=true)

#### 快速开始

1. 安装

- [Package Manager](https://www.nuget.org/packages/Auto.Options)

```
Install-Package Auto.Options
```

- [.NET CLI](https://www.nuget.org/packages/Auto.Options)

```
dotnet add package Auto.Options
```

2. 注册AutoCore

```c#
builder.Services.AddAutoOptions(builder.Configuration);
```

3. 配置

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

4.  获取配置选项扩展方法

```C#
public static T GetOptions<T>(this IConfiguration configuration)

public static T GetOptions<T>(this IConfiguration configuration, string node)

public static T GetOptions<T>(this IServiceProvider serviceProvider, OptionsType optionsType = OptionsType.OptionsSnapshot) where T : class


```

