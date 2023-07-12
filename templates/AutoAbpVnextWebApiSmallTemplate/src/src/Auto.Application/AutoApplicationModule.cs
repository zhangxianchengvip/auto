using Auto.Doamin;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Auto.Application;

[DependsOn(
    typeof(AbpDddApplicationModule)
    , typeof(AutoDomainModule)
)]
public class AutoApplicationModule : AbpModule
{
}