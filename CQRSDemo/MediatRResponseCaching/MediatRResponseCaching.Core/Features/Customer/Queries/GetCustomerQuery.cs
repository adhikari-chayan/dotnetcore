using MediatR;
using MediatRResponseCaching.Core.Abstractions;
using System;

namespace MediatRResponseCaching.Core.Features.Customer.Queries
{
    public class GetCustomerQuery : IRequest<Entities.Customer>, ICacheableMediatrQuery
    {
        public int Id { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Customer-{Id}";
        public TimeSpan? SlidingExpiration { get; set; }
    }
}
