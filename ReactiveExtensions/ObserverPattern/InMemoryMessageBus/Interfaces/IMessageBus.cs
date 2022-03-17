namespace InMemoryMessageBus.Interfaces
{
    public interface IMessageBus
    {
        IMessagePublisher GetPublisher();
        IDisposable RegisterListener(IMessageListener listener);

        void DisposeMessageBus();
    }
}
