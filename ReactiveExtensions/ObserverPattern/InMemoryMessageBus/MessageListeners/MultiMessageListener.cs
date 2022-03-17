using InMemoryMessageBus.Interfaces;
using InMemoryMessageBus.Messages;

namespace InMemoryMessageBus.MessageListeners
{
    public class MultiMessageListener: IMessageListener
    {
        public MultiMessageListener()
        {
            Filters = new[]
            {
                MessageType.Payment, MessageType.Product
            };
        }

        public IEnumerable<MessageType> Filters { get; }
        public void OnReceived(IMessage message)
        {
            if(message.MessageType == MessageType.Product)
            {
                var productMessage = MessageHelpers.ValidateIncomingMessage<ProductMessage>(message);
                Console.WriteLine($"MultiListener | Product message with message id {message.MessageId} is processed | Product Id - {productMessage.ProductPayload.Id} | Product Name - {productMessage.ProductPayload.Name} | Price - {productMessage.ProductPayload.Price}");

                return;
            }

            var paymentMessage = MessageHelpers.ValidateIncomingMessage<PaymentMessage>(message);
            Console.WriteLine($"MultiListener | Payment message with message id {message.MessageId} is processed | Payemnt Id - {paymentMessage.PaymentPayload.Id} | Order Id - {paymentMessage.PaymentPayload.OrderId} | Amount - {paymentMessage.PaymentPayload.Amount}");
        }
    }
}
