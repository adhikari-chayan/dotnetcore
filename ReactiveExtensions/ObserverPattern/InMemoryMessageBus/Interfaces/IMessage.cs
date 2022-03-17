namespace InMemoryMessageBus.Interfaces
{
    public interface IMessage
    {
        string MessageId { get; }
        MessageType MessageType { get; }
    }

    public enum MessageType
    {
        Order,        
        Product,
        Payment
    }
}
