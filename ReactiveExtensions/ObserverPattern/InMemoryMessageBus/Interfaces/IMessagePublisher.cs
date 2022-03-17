using InMemoryMessageBus.Response;

namespace InMemoryMessageBus.Interfaces
{
    public interface IMessagePublisher
    {
        PublishResult Publish(IMessage message);
    }
}
