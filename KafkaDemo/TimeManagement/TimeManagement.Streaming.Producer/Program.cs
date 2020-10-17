using System;
using System.Threading.Tasks;

namespace TimeManagement.Streaming.Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter your message. Enter q for quitting");
            var message = default(string);
            while ((message = Console.ReadLine()) != "q")
            {
                var producer = new BookingProducer();
                await producer.Produce(message);
            }
        }
    }
}
