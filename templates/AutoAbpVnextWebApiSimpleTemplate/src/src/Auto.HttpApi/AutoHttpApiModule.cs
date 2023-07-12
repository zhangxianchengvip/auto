using Auto.Application.Contracts;
using Auto.Domain.Shared.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Auto.HttpApi
{
    [DependsOn(
        typeof(AutoApplicationContractsModule)
        , typeof(AbpAspNetCoreMvcModule)
    )]
    public class AutoHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AutoHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AutoResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}