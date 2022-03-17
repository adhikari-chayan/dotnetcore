namespace InMemoryMessageBus.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public List<Product> OrderItems { get; set; } = new List<Product>();
        
    }
}
