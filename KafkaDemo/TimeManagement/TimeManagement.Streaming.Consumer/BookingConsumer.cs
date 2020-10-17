using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TimeManagement.Streaming.Consumer
{
    public class BookingConsumer : IBookingConsumer
    {
        public void Listen(Action<string> message)
        {
            var conf = new ConsumerConfig
            {
                GroupId = "booking_consumer",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Null, string>(conf).Build();
            consumer.Subscribe("timemanagement_booking");
           
            // Because Consume is a blocking call, we want to capture Ctrl+C and use a cancellation token to get out of our while loop and close the consumer gracefully.
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    // Consume a message from the timemanagement_booking topic. Pass in a cancellation token so we can break out of our loop when Ctrl+C is pressed
                    var cr = consumer.Consume(cts.Token);
                    Console.WriteLine($"Consumed message '{cr.Message.Value}' from topic {cr.Topic}, partition {cr.Partition}, offset {cr.Offset}");

                    // Do something interesting with the message you consumed
                }
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                consumer.Close();
            }

        }
    }
}
