using Auto.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Auto.Application.Contracts;

[DependsOn(
    typeof(AbpDddApplicationContractsModule)
    ,typeof(AutoDomainSharedModule)
)]
public class AutoApplicationContractsModule : AbpModule
{
}