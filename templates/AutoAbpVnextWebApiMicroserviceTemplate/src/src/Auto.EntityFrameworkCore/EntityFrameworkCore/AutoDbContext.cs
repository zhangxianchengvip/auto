using Auto.Doamin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Auto.EntityFrameworkCore.EntityFrameworkCore;

[ConnectionStringName(AutoDbProperties.ConnectionStringName)]
public class AutoDbContext : AbpDbContext<AutoDbContext>, IAutoDbContext
{
    //public virtual DbSet<Order> Orders { get; set; }

    public AutoDbContext(DbContextOptions<AutoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /* Include modules to your migration db context */


        /* Configure your own tables/entities inside here */
    }
}