using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IHttpClientFactory httpClientFactory, ILogger<WeatherForecastController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        public async Task<WeatherModel> Get([FromQuery] string zip)
        {
            using (var client = _httpClientFactory.CreateClient("weather"))
            {
                var response = await client.GetAsync($"weather?zip={zip},us&appid=ab5b4979710a673a17144508d6c77937E");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherModel>(data);
                }
                return null;
            }
        }

    }

    public class WeatherModel
    {
        public MainModel Main { get; set; }
    }

    public class MainModel
    {
        public decimal Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}
