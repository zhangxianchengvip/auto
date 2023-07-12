using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Auto.Doamin;

[DependsOn(
    typeof(AbpDddDomainModule)
)]
public class AutoDomainModule : AbpModule
{
}