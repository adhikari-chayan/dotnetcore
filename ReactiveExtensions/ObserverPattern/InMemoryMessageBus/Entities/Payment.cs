namespace InMemoryMessageBus.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }

        public int Amount { get; set; }
    }
}
