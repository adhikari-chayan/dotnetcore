using EventDriven.DDD.Abstractions.Entities;

namespace EventDriven.DDD.Abstractions.Events;

/// <summary>
/// A statement of fact about what change has been made to the domain state.
/// </summary>
/// <param name="EntityId">The id of the entity that this event is about.</param>
/// <param name="EntityETag">A unique id that must change atomically with each store of the entity.</param>
public abstract record DomainEvent(Guid EntityId, string? EntityETag = null)
    : Event, IDomainEvent;

/// <summary>
/// A statement of fact about what change has been made to the domain state.
/// </summary>
/// <param name="Entity">The entity that this event is about.</param>
/// <param name="EntityId">The id of the entity that this event is about.</param>
/// <param name="EntityETag">A unique id that must change atomically with each store of the entity.</param>
/// <typeparam name="TEntity">Entity type.</typeparam>
public abstract record DomainEvent<TEntity>(TEntity? Entity, Guid EntityId = default, string? EntityETag = null) :
    IDomainEvent<TEntity>
    where TEntity : IEntity
{
    /// <inheritdoc />
    public Guid Id { get; set; }

    /// <inheritdoc />
    public Guid EntityId { get; } = Entity?.Id ?? EntityId;

    /// <inheritdoc />
    public string? EntityETag { get; } = Entity?.ETag ?? EntityETag;

    /// <inheritdoc />
    public TEntity? Entity { get; } = Entity;
}    