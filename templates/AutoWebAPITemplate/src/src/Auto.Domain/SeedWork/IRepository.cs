using System.Linq.Expressions;

namespace Auto.Domain.SeedWork;

/// <summary>
/// 仓储基类（用于实现工作单元）
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T, key> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }

    Task<T> InsertAsync(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
}