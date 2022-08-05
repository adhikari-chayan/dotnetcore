namespace EventDriven.DDD.Abstractions.Events;

/// <summary>
/// Event handler.
/// </summary>
/// <typeparam name="TEvent">Event type.</typeparam>
public interface IEventHandler<in TEvent> where TEvent : class, IDomainEvent
{
    /// <summary>
    /// Handles an event.
    /// </summary>
    /// <param name="domainEvent">The event.</param>
    /// <returns>True if handled successfully.</returns>
    Task<bool> Handle(TEvent domainEvent);
}