using System;
using System.Collections.Generic;
using System.Text;

namespace MediatRResponseCaching.Core.Abstractions
{
   public interface ICacheableMediatrQuery
    {
        bool BypassCache { get; }
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
