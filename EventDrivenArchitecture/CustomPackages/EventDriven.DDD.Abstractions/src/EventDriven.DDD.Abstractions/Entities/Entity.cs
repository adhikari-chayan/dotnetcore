namespace EventDriven.DDD.Abstractions.Entities;

/// <inheritdoc />
public abstract class Entity : IEntity
{
    /// <inheritdoc />
    public Guid Id { get; set; }

    /// <inheritdoc />
    public string? ETag { get; set; }
}
