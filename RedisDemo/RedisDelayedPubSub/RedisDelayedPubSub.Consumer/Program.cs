using System;
using System.Threading;
using System.Threading.Tasks;

namespace RedisDelayedPubSub.Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Waiting for keys....");

            CancellationTokenSource cts = new CancellationTokenSource();
            await new RedisDelayedConsumer().Subscribe(cts.Token);

            Console.ReadLine();
        }
    }
}
