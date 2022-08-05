namespace EventDriven.DDD.Abstractions.Repositories;

/// <summary>
/// An exception that is thrown when the supplied concurrency token does not match the existing concurrency token.
/// </summary>
public class ConcurrencyException : Exception
{
    private const string ExceptionMessage = 
        "An exception that is thrown when the supplied concurrency token does not match the existing concurrency token.";
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public ConcurrencyException() : base(ExceptionMessage) { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ConcurrencyException(string message) : base(message) { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">The exception that is the cause of the current exception.</param>
    public ConcurrencyException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="entityId">Entity identifier.</param>
    public ConcurrencyException(string message, Guid entityId) : base(message)
    {
        EntityId = entityId;
    }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="entityId">Entity identifier.</param>
    public ConcurrencyException(Guid entityId) : base(ExceptionMessage)
    {
        EntityId = entityId;
    }

    /// <summary>
    /// Entity identifier.
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public Guid EntityId { get; set; }
}