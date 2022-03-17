using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProtobuDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtobuDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast([FromQuery(Name ="date")] DateTime? dateTime = null)
        {
            return Ok(await _weatherForecastService.GetWeatherForecastForDay(dateTime ?? DateTime.UtcNow.Date));
        }
    }
}
