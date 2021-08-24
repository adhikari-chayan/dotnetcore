using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.Retry;
using Polly.Wrap;

namespace Monolith
{
    [Route("[action]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncFallbackPolicy<IActionResult> _fallbackPolicy;
        private readonly AsyncRetryPolicy<IActionResult> _retryPolicy;

        //It’s worth noting this is a little different from how we declare our other policies, in that we are using a static access modifier. The reason for this is circuit breaker relies on a shared state, to track failures across requests. By default, a .NET 5 controller class is instantiated on every request, so we need to implement a custom singleton. A better approach here would be to include our code in a service and use the Dependency Injection container built into .NET to mark it as a singleton.

        private static AsyncCircuitBreakerPolicy _circuitBreakerPolicy;

        private readonly AsyncPolicyWrap<IActionResult> _policy;

        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _fallbackPolicy = Policy<IActionResult>
                .Handle<Exception>()
                .FallbackAsync(Content("Sorry, we are currently experiencing issues. Please try again later"));

            _retryPolicy = Policy<IActionResult>
                .Handle<Exception>()
                .RetryAsync();

            if(_circuitBreakerPolicy == null)
            {
                _circuitBreakerPolicy = Policy
                    .Handle<Exception>()
                    .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));


            }


            //we declare a fallback policy (same as previous), then wrap that with our retry policy, then wrap that with a circuit breaker. Effectively we are saying: retry once, fallback to what we specify, and open a circuit for 1 minute if 2 errors occur.
            _policy = Policy<IActionResult>
            .Handle<Exception>()
            .FallbackAsync(Content("Sorry, we are currently experiencing issues. Please try again later"))
            .WrapAsync(_retryPolicy)
            .WrapAsync(_circuitBreakerPolicy);

            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> Books()
            => await ProxyTo("https://localhost:5101/books");

        [HttpGet]
        public async Task<IActionResult> Authors()
            => await ProxyTo("https://localhost:5001/authors");

        private async Task<IActionResult> ProxyTo(string url)
            => //await _fallbackPolicy.ExecuteAsync(async()  => Content(await _httpClient.GetStringAsync(url)));
               //await _retryPolicy.ExecuteAsync(async () => Content(await _httpClient.GetStringAsync(url)));
               //await _circuitBreakerPolicy.ExecuteAsync(async () => Content(await _httpClient.GetStringAsync(url)));
            await _policy.ExecuteAsync(async () => Content(await _httpClient.GetStringAsync(url)));

    }
}
