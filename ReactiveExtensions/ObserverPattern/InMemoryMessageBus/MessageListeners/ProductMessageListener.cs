using InMemoryMessageBus.Interfaces;
using InMemoryMessageBus.Messages;

namespace InMemoryMessageBus.MessageListeners
{
    public class ProductMessageListener : IMessageListener
    {
        public ProductMessageListener()
        {
            Filters = new[]
            {
                MessageType.Product
            };
        }

        public IEnumerable<MessageType> Filters { get; }
        public void OnReceived(IMessage message)
        {
            var productMessage = MessageHelpers.ValidateIncomingMessage<ProductMessage>(message);
            Console.WriteLine($"Product message with message id {message.MessageId} is processed | Product Id - {productMessage.ProductPayload.Id} | Product Name - {productMessage.ProductPayload.Name} | Price - {productMessage.ProductPayload.Price}");
        }
    }
}
