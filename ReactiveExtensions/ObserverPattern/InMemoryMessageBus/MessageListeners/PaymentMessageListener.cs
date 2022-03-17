using InMemoryMessageBus.Interfaces;
using InMemoryMessageBus.Messages;

namespace InMemoryMessageBus.MessageListeners
{
    public class PaymentMessageListener : IMessageListener
    {
        public PaymentMessageListener()
        {
            Filters = new[]
            {
                MessageType.Payment
            };
        }

        public IEnumerable<MessageType> Filters { get; }
        public void OnReceived(IMessage message)
        {
            var paymentMessage = MessageHelpers.ValidateIncomingMessage<PaymentMessage>(message);
            Console.WriteLine($"Payment message with message id {message.MessageId} is processed | Payemnt Id - {paymentMessage.PaymentPayload.Id} | Order Id - {paymentMessage.PaymentPayload.OrderId} | Amount - {paymentMessage.PaymentPayload.Amount}");
        }
    }
}
