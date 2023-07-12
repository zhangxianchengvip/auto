using Auto.Domain.Shared;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Auto.Doamin;

[DependsOn(
    typeof(AbpDddDomainModule)
    , typeof(AutoDomainSharedModule)
)]
public class AutoDomainModule : AbpModule
{
}