using Auto.Doamin;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Auto.EntityFrameworkCore.EntityFrameworkCore
{
    [ConnectionStringName(AutoDbProperties.ConnectionStringName)]
    public interface IAutoDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        //DbSet<Order> Orders { get; }
    }
}