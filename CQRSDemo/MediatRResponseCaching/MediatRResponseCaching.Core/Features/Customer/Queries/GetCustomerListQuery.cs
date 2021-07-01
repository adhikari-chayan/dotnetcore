using MediatR;
using MediatRResponseCaching.Core.Abstractions;
using System;
using System.Collections.Generic;

namespace MediatRResponseCaching.Core.Features.Customer.Queries
{
    public class GetCustomerListQuery : IRequest<List<Entities.Customer>>, ICacheableMediatrQuery
    {
        public int Id { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"CustomerList";
        public TimeSpan? SlidingExpiration { get; set; }
    }
}
