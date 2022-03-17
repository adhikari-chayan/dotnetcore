using InMemoryMessageBus.Entities;
using InMemoryMessageBus.Interfaces;

namespace InMemoryMessageBus.Messages
{
    public class ProductMessage : IMessage
    {
        public ProductMessage(string messageId, Product product)
        {
            MessageId = messageId;
            ProductPayload = product;
        }

        public string MessageId { get; set; }
        public MessageType MessageType => MessageType.Product;

        public Product ProductPayload { get; set; }
    }
}
