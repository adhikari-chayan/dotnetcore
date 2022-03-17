using InMemoryMessageBus.Interfaces;
using InMemoryMessageBus.Response;

namespace InMemoryMessageBus
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IObserver<IMessage> messagesStream;
        public MessagePublisher(IObserver<IMessage> messagesStream)
        {
            this.messagesStream = messagesStream;
        }
        public PublishResult Publish(IMessage message)
        {
            try
            {
                messagesStream.OnNext(message);
                return SuccessPublishResult.Instance;
            }
            catch (Exception ex)
            {
                return new FailedPublishResult($"Failed publishing message: {message?.MessageId}", ex);
            }
        }
    }
}
