namespace EventDriven.DDD.Abstractions.Events;

/// <summary>
/// A statement of fact about what change has been made to the domain state.
/// </summary>
public record Event : IEvent
{
    /// <inheritdoc />
    public Guid Id { get; set; }
}