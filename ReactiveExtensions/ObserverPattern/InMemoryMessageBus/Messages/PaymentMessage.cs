using InMemoryMessageBus.Entities;
using InMemoryMessageBus.Interfaces;

namespace InMemoryMessageBus.Messages
{
    public class PaymentMessage : IMessage
    {
        public PaymentMessage(string messageId, Payment payment)
        {
            MessageId = messageId;
            PaymentPayload = payment;
        }

        public string MessageId { get; set; }
        public MessageType MessageType => MessageType.Payment;

        public Payment PaymentPayload { get; set; }
    }
}