using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeManagement.Streaming.Producer
{
    public class BookingProducer : IBookingProducer
    {
        public async Task Produce(string message)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            // Create a producer that can be used to send messages to kafka that have no key and a value of type string 
            using var p = new ProducerBuilder<Null, string>(config).Build();

            var i = 0;
            // Construct the message to send (generic type must match what was used above when creating the producer)
            var kafkaMessage = new Message<Null, string>
            {
                Value = message
            };

            // Send the message to our test topic in Kafka                
            var dr = await p.ProduceAsync("timemanagement_booking", kafkaMessage);
            Console.WriteLine($"Produced message '{dr.Value}' to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}");

            Thread.Sleep(5000);
           
        }
    }
}
