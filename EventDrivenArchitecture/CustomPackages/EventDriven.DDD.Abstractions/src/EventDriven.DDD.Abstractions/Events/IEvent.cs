namespace EventDriven.DDD.Abstractions.Events;

/// <summary>
/// A statement of fact about what change has been made to the domain state.
/// </summary>
public interface IEvent
{
    /// <summary>
    /// Unique ID of the event.
    /// </summary>
    Guid Id { get; set; }
}