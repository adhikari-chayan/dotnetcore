using System;

namespace PricingApi.Models
{
    public class PricingDetails
    {
        public Guid ProductId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Price { get; set; }
    }
}
