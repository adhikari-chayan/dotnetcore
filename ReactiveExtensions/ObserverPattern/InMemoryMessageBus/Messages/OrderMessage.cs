using InMemoryMessageBus.Entities;
using InMemoryMessageBus.Interfaces;

namespace InMemoryMessageBus.Messages
{
    public class OrderMessage : IMessage
    {      
       public OrderMessage(string messageId, Order order)
       {
            MessageId = messageId;
            OrderPayload = order;
       }

       public string MessageId { get; set; }
       
       public MessageType MessageType => MessageType.Order;

       public Order OrderPayload { get; set; }
        
    }
}