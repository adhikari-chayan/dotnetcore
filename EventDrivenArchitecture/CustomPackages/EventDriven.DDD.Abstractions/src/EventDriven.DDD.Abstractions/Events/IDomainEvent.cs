using EventDriven.DDD.Abstractions.Entities;

namespace EventDriven.DDD.Abstractions.Events;

/// <inheritdoc />
public interface IDomainEvent : IEvent
{
    /// <summary>
    /// The id of the entity that this event is about.
    /// </summary>
    Guid EntityId { get; }

    /// <summary>
    /// The etag of the entity that this event is about.
    /// </summary>
    public string? EntityETag { get; }
}

/// <summary>
/// A statement of fact about what change has been made to the domain state.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public interface IDomainEvent<out TEntity> : IDomainEvent
    where TEntity : IEntity
{
    /// <summary>
    /// The entity the domain event is in reference to.
    /// </summary>
    public TEntity? Entity { get; }
}
