using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Wrap;
using ProductApi.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public class PricingService : IPricingService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private static readonly Random Jitterer = new Random();
        
        private static readonly AsyncRetryPolicy<HttpResponseMessage> _transientErrorRetryPolicy =
            Policy.HandleResult<HttpResponseMessage>(message => ((int)message.StatusCode) == 429 || (int)message.StatusCode >= 500)
                .WaitAndRetryAsync(2, retryAttempt =>
                {
                    Console.WriteLine($"Retrying because of transient error. Attempt {retryAttempt}");
                    return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + TimeSpan.FromMilliseconds(Jitterer.Next(0, 1000));
                });

        private static readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> _circuitBreakerPolicy =
            Policy.HandleResult<HttpResponseMessage>(message => (int)message.StatusCode == 503)
                //.AdvancedCircuitBreakerAsync(0.5,
                //    TimeSpan.FromMinutes(1),
                //    100,
                //    TimeSpan.FromMinutes(1));
                .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1),
                    (message, t) =>
                    {
                        Console.WriteLine("Circuit Broken!!");
                    },
                    () =>
                    {
                        Console.WriteLine("Circuit Reset!!");
                    }
                 );

        private readonly AsyncPolicyWrap<HttpResponseMessage> _resilientPolicy =
            _transientErrorRetryPolicy.WrapAsync(_circuitBreakerPolicy);



        public PricingService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
          
        }

        public async Task<PricingDetails> GetPricingForProductAsync(Guid productId, string currencyCode)
        {
            if(_circuitBreakerPolicy.CircuitState == CircuitState.Open)
            {
                throw new Exception("Service is currently unavailable");
            }

            var httpClient = _httpClientFactory.CreateClient();

            //Not Working on wrapping _transientErrorRetryPolicy

            //var response = await _transientErrorRetryPolicy.ExecuteAsync(() =>
            //    _circuitBreakerPolicy.ExecuteAsync(() =>
            //        httpClient.GetAsync($"https://localhost:44310/api/pricing/products/{productId}/currencies/{currencyCode}")));



            var response = await _resilientPolicy.ExecuteAsync(() =>
                httpClient.GetAsync($"https://localhost:44310/api/pricing/products/{productId}/currencies/{currencyCode}")
                    );

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Service is currently unavailable");
            }

            var responseText = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PricingDetails>(responseText);
        }
    }
}
