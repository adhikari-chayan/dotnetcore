namespace OldStyleApi.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get;set; }
    }
}
