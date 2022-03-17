using ProtoBuf;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProtobuDemo.Services
{
    public class CachedWeatherForecastService : IWeatherForecastService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IWeatherForecastService _weatherForecastService;
        public CachedWeatherForecastService(IConnectionMultiplexer connectionMultiplexer, IWeatherForecastService weatherForecastService)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _weatherForecastService = weatherForecastService;
        }
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastForDay(DateTime dateTime)
        {
            var database = _connectionMultiplexer.GetDatabase();
            var cachedValue = await database.StringGetAsync($"forecast-{dateTime.Date:dd/MM/yyyy}");

            if (cachedValue.HasValue)
            {
                //Json Desrialization
                
                //return JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(cachedValue.ToString());

                //Protobuf Deserialization
                
                return Serializer.Deserialize<IEnumerable<WeatherForecast>>(cachedValue);
            }

            var weatherForecast = await _weatherForecastService.GetWeatherForecastForDay(dateTime);

            //Json Serialization
            
            //await database.StringSetAsync($"forecast-{dateTime.Date:dd/MM/yyyy}", JsonSerializer.Serialize<IEnumerable<WeatherForecast>>(weatherForecast));


            //Protobuf Serialization
            await database.StringSetAsync($"forecast-{dateTime.Date:dd/MM/yyyy}", ProtoSerialize<IEnumerable<WeatherForecast>>(weatherForecast),TimeSpan.FromMinutes(1));

            return weatherForecast;
        }

        private static byte[] ProtoSerialize<T>(T record) where T : class
        {
            using var stream = new MemoryStream();
            Serializer.Serialize(stream, record);
            return stream.ToArray();
        }
    }
}
