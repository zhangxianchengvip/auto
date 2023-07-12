using Auto.Domain.SeedWork;
using Auto.EntityFrameworkCore.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Auto.EntityFrameworkCore;

public class AutoDbContext : DbContext,IUnitOfWork
{
    private readonly IMediator? _mediator;

    public AutoDbContext(DbContextOptions<AutoDbContext> options) : base(options)
    {
    }

    public AutoDbContext(DbContextOptions<AutoDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //FunltApi配置
        // modelBuilder.ApplyConfiguration(new DeveloperAccountEntityTypeConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await _mediator.DispatchDomainEventsAsync(this);
        var result = await base.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}