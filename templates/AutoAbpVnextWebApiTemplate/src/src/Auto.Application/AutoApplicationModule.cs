using Auto.Application.Contracts;
using Auto.Doamin;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Auto.Application;

[DependsOn(
    typeof(AbpDddApplicationModule)
    , typeof(AutoApplicationContractsModule)
    , typeof(AutoDomainModule)
)]
public class AutoApplicationModule : AbpModule
{
}