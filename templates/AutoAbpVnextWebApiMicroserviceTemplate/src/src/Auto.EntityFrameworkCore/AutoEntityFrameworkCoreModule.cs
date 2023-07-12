using Auto.Doamin;
using Auto.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

using Volo.Abp.Modularity;

namespace Auto.EntityFrameworkCore
{
    [DependsOn(
        typeof(AutoDomainModule)
        , typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AutoEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AutoDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also OrderingServiceMigrationsDbContextFactory for EF Core tooling. */

            });
        }
    }
}