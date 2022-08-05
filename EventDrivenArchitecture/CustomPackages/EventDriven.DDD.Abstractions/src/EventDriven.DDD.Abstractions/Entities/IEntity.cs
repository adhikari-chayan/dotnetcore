namespace EventDriven.DDD.Abstractions.Entities;

/// <summary>
/// A type that has an identity with behavior and state that can change over time.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// The ID of the Entity.
    /// </summary>
    Guid Id { get; set; }

    /// <summary>
    /// Represents a unique ID that must change atomically with each store of the entity
    /// to its underlying storage medium.
    /// </summary>
    string? ETag { get; set; }
}
