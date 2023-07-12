using MediatR;

namespace Auto.Domain.SeedWork;

public abstract class Entity
{
    private List<INotification>? _domainEvents;
    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}

/// <summary>
/// 实体（标记是否为实体）
/// </summary>
public abstract class Entity<T> : Entity
{
    public T Id { get; init; }

    internal Entity(T id)
    {
        Id = id;
    }
}