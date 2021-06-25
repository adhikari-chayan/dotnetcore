using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtobuDemo.Services
{
   public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastForDay(DateTime dateTime);
    }
}
