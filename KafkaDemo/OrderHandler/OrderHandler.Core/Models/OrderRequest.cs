using System;

namespace OrderHandler.Core.Models
{
    public class OrderRequest
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }
    }
    public enum OrderStatus
    {
        INPROGRESS,
        COMPLETED,
        REJECTED
    }
}
