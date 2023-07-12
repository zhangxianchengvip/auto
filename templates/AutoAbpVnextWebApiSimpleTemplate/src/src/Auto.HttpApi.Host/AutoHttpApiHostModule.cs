using Auto.Application;
using Auto.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Auto.HttpApi.Host;

[DependsOn(
    typeof(AutoApplicationModule)
    ,typeof(AutoHttpApiModule)
    ,typeof(AutoEntityFrameworkCoreModule)
)]
public class AutoHttpApiHostModule : AbpModule
{
}