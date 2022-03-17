using System;
using System.Threading.Tasks;

namespace RedisDelayedPubSub.Sender
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var publisher = new RedisDelayedPublisher();
            while (true)
            {
                Console.Write("Enter key name:");
                var key  = Console.ReadLine();

                Console.Write("Delay in sec:");
                var delay = int.Parse( Console.ReadLine());

                await publisher.Publish(key, delay);
            }
        }
    }
}
