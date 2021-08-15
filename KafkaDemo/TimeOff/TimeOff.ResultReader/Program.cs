using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;
using TimeOff.Core;
using TimeOff.Models;

namespace TimeOff.ResultReader
{
   internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("TimeOff Results Terminal\n");

            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .Build();

            var configReader = new ConfigReader(configuration);

            var schemaRegistryConfig = configReader.GetSchemaRegistryConfig();
            var consumerConfig = configReader.GetConsumerConfig();

            CachedSchemaRegistryClient cachedSchemaRegistryClient = new CachedSchemaRegistryClient(schemaRegistryConfig);

            using var consumer = new ConsumerBuilder<string, LeaveApplicationProcessed>(consumerConfig)
               .SetKeyDeserializer( new AvroDeserializer<string>(cachedSchemaRegistryClient).AsSyncOverAsync())
               .SetValueDeserializer(new AvroDeserializer<LeaveApplicationProcessed>(cachedSchemaRegistryClient).AsSyncOverAsync())
               .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
               .Build();
            {
                try
                {
                    Console.WriteLine("");
                    consumer.Subscribe(ApplicationConstants.LeaveApplicationResultsTopicName);

                    while (true)
                    {
                        var result = consumer.Consume();
                        var leaveRequest = result.Message.Value;
                        Console.WriteLine($"Received message: {result.Message.Key} Value: {JsonSerializer.Serialize(leaveRequest)}");
                        consumer.Commit(result);
                        consumer.StoreOffset(result);
                        Console.WriteLine("\nOffset committed");
                        Console.WriteLine("----------\n\n");
                    }

                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Consume error: {e.Error.Reason}");
                }
                finally
                {
                    consumer.Close();
                }
            }
        }
    }
}
