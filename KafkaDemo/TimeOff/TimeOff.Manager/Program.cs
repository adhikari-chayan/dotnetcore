using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TimeOff.Core;
using TimeOff.Models;

namespace TimeOff.Manager
{
    public record KafkaMessage(string Key, int Partition, LeaveApplicationReceived Message);
   internal class Program
    {
        private static ConfigReader _configReader;
        private static AdminClientConfig _adminConfig;
        private static SchemaRegistryConfig _schemaRegistryConfig;
        private static ConsumerConfig _consumerConfig;
        private static ProducerConfig _producerConfig;

        private static Queue<KafkaMessage> _leaveApplicationReceivedMessages;

        public static IConfiguration Configuration { get; private set; }


        private static async Task Main()
        {
            Console.WriteLine("TimeOff Manager Terminal\n");

            Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

            _configReader = new ConfigReader(Configuration);

            //Read Configs
            _schemaRegistryConfig = _configReader.GetSchemaRegistryConfig();
            _consumerConfig = _configReader.GetConsumerConfig();
            _producerConfig = _configReader.GetProducerConfig();

            //Create Topic
            _adminConfig = _configReader.GetAdminConfig();
            await KafkaHelper.CreateTopicAsync(_adminConfig, ApplicationConstants.LeaveApplicationResultsTopicName,
                1);

            _leaveApplicationReceivedMessages = new Queue<KafkaMessage>();

            await Task.WhenAny(Task.Run(StartManagerConsumer), Task.Run(StartLeaveApplicationProcessor));

        }

        private static async Task StartLeaveApplicationProcessor()
        {
            while (true)
            {
                if (!_leaveApplicationReceivedMessages.Any())
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    continue;
                }

                var (key, partition, leaveApplication) = _leaveApplicationReceivedMessages.Dequeue();
                Console.WriteLine($"Received message: {key} from partition: {partition} Value: {JsonSerializer.Serialize(leaveApplication)}");

                // Make decision on leave request.
                var isApproved = ReadLine.Read("Approve request? (Y/N): ", "Y")
                    .Equals("Y", StringComparison.OrdinalIgnoreCase);

                await SendMessageToResultTopicAsync(leaveApplication, isApproved, partition);
            }
        }

        private static Task StartManagerConsumer()
        {
            CachedSchemaRegistryClient cachedSchemaRegistryClient = new CachedSchemaRegistryClient(_schemaRegistryConfig);

            using var consumer = new ConsumerBuilder<string, LeaveApplicationReceived>(_consumerConfig)
                 .SetKeyDeserializer(new AvroDeserializer<string>(cachedSchemaRegistryClient).AsSyncOverAsync())
                 .SetValueDeserializer(new AvroDeserializer<LeaveApplicationReceived>(cachedSchemaRegistryClient).AsSyncOverAsync())
                 .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                 .Build();
            {
                try
                {
                    consumer.Subscribe(ApplicationConstants.LeaveApplicationsTopicName);
                    Console.WriteLine("Consumer loop started...\n");
                    while(true)
                    {
                        try
                        {
                            // We will give the process 1 second to commit the message and store its offset.
                            var result = consumer.Consume(TimeSpan.FromMilliseconds(_consumerConfig.MaxPollIntervalMs - 1000 ?? 250000));

                            var leaveRequest = result?.Message?.Value;
                            if(leaveRequest == null)
                            {
                                continue;
                            }

                            // Adding message to a list just for the demo
                            // You should persist the message in database and process it later
                            _leaveApplicationReceivedMessages.Enqueue(new KafkaMessage(result.Message.Key, result.Partition.Value, result.Message.Value));

                            consumer.Commit(result);
                            consumer.StoreOffset(result);
                            Console.WriteLine("\nOffset committed");
                            Console.WriteLine("----------\n\n");
                        }
                        catch(ConsumeException e) when (!e.Error.IsFatal)
                        {
                            Console.WriteLine($"Non fatal error: {e}");
                        }
                    }
                }
                finally
                {
                    consumer.Close();
                }
            }
        }

        private static async Task SendMessageToResultTopicAsync(LeaveApplicationReceived leaveRequest, bool isApproved, int partitionId)
        {
            CachedSchemaRegistryClient cachedSchemaRegistryClient = new CachedSchemaRegistryClient(_schemaRegistryConfig);

            using var producer = new ProducerBuilder<string, LeaveApplicationProcessed>(_producerConfig)
                .SetKeySerializer(new AvroSerializer<string>(cachedSchemaRegistryClient))
                .SetValueSerializer(new AvroSerializer<LeaveApplicationProcessed>(cachedSchemaRegistryClient))
                .Build();
            {
                var leaveApplicationResult = new LeaveApplicationProcessed
                {
                    EmpDepartment = leaveRequest.EmpDepartment,
                    EmpEmail = leaveRequest.EmpEmail,
                    LeaveDurationInHours = leaveRequest.LeaveDurationInHours,
                    LeaveStartDateTicks = leaveRequest.LeaveStartDateTicks,
                    ProcessedBy = $"Manager #{partitionId}",
                    Result = isApproved
                       ? "Approved: Your leave application has been approved."
                       : "Declined: Your leave application has been declined."
                };

                var result = await producer.ProduceAsync(ApplicationConstants.LeaveApplicationResultsTopicName,
                  new Message<string, LeaveApplicationProcessed>
                  {
                      Key = $"{leaveRequest.EmpEmail}-{DateTime.UtcNow.Ticks}",
                      Value = leaveApplicationResult
                  });
                Console.WriteLine(
                    $"\nMsg: Leave request processed and queued at offset {result.Offset.Value} in the Topic {result.Topic}");
            }
        }
   }
}

