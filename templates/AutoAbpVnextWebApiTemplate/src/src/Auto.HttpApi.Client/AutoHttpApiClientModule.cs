using Auto.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Auto.HttpApi.Client
{
    [DependsOn(
        typeof(AutoApplicationContractsModule)
        , typeof(AbpHttpClientModule)
    )]
    public class AutoHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Autoing";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStaticHttpClientProxies(
                typeof(AutoApplicationContractsModule).Assembly,
                RemoteServiceName
            );

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AutoHttpApiClientModule>();
            });
        }
    }
}