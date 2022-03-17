namespace InMemoryMessageBus.Interfaces
{
    public interface IMessageListener
    {
        IEnumerable<MessageType> Filters { get; }

        void OnReceived(IMessage message);
    }
}