using InMemoryMessageBus.Interfaces;
using InMemoryMessageBus.Messages;

namespace InMemoryMessageBus.MessageListeners
{
    public class OrderMessageListener : IMessageListener
    {
        public OrderMessageListener()
        {
            Filters = new[]
            {
                MessageType.Order
            };
        }

        public IEnumerable<MessageType> Filters { get; }
        public void OnReceived(IMessage message)
        {
            var orderMessage = MessageHelpers.ValidateIncomingMessage<OrderMessage>(message);
            Console.WriteLine($"Order message with message id {message.MessageId} is Processed | Order Id - {orderMessage.OrderPayload.Id}");
        }
    }
}
