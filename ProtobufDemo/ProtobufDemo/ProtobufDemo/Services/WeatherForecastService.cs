using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtobuDemo.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastForDay(DateTime dateTime)
        {
            var rng = new Random();
            return await Task.FromResult(Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray());
        }
    }
}
