using Confluent.Kafka;
using Newtonsoft.Json;

var config = new ConsumerConfig
             {
	             GroupId = "weather-consumer-group",
	             BootstrapServers = "localhost:9092",
	             AutoOffsetReset = AutoOffsetReset.Earliest,

             };

using var consumer = new ConsumerBuilder<Null, string>(config).Build();

consumer.Subscribe("weather-topic");

CancellationTokenSource cts = new();

try
{
	while (true)
	{
		var response = consumer.Consume(cts.Token);
		if (response.Message is not null)
		{
			var weather = JsonConvert.DeserializeObject<Weather>(response.Message.Value);
			Console.WriteLine($"State: {weather.State}, Temp: {weather.Temperature}F");
		}
	}
}
catch (Exception)
{

}

public record Weather(string State, int Temperature);