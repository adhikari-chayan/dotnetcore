using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelBasic
{
    class Program
    {
       static Action<string> WriteLineWithTime =
       (str) => Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] {str}");
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Basic usage\n2.Generator Demo\n3.Multiplexing Demo\n4.Demultiplexing Demo\n5.Run Timeout\n6.Run Quit Channel\n7.Run Web Search");
            Console.WriteLine("----------------");
            Console.Write("Enter choice:");
            var choice=Console.ReadLine();

            switch (Convert.ToInt32(choice))
            {
                case 1:
                    await RunBasicChannelUsage();
                    break;
                case 2:
                    await RunGenerator();
                    break;
                case 3:
                    await RunMultiplexing();
                    break;
                case 4:
                    await RunDemultiplexing();
                    break;
                case 5:
                    await RunTimeout();
                    break;
                case 6:
                    await RunQuitChannel();
                    break;
                case 7:
                    await RunWebSearch();
                    break;
            }
            
            Console.ReadKey();
        }

        public static async Task RunBasicChannelUsage()
        {
            var ch = Channel.CreateUnbounded<string>();
            var consumer = Task.Run(async () =>
            {
                while (await ch.Reader.WaitToReadAsync())
                    WriteLineWithTime(await ch.Reader.ReadAsync());
            });

            var producer = Task.Run(async () =>
            {
                var rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    await Task.Delay(TimeSpan.FromSeconds(rnd.Next(3)));
                    await ch.Writer.WriteAsync($"Message {i}");
                }
                ch.Writer.Complete();
            });

            await Task.WhenAll(producer, consumer);
        }

       public static async Task RunGenerator()
        {
            var joe = CreateMessenger("Joe", 5);
            
            await foreach (var item in joe.ReadAllAsync())
                Console.WriteLine(item);

        }

        public static async Task RunMultiplexing()
        {
            var ch = Merge(CreateMessenger("Joe", 3), CreateMessenger("Ann", 5));

            await foreach (var item in ch.ReadAllAsync())
                WriteLineWithTime(item);
        }

        public static async Task RunDemultiplexing()
        {
            var joe = CreateMessenger("Joe", 10);
            var readers = Split(joe, 3);
            var tasks = new List<Task>();

            for(int i = 0; i < readers.Count; i++)
            {
                var reader = readers[i];
                var index = i;
                tasks.Add(Task.Run(async () =>
                {
                    await foreach (var item in reader.ReadAllAsync())
                    {
                        Console.WriteLine($"Reader {index}: {item}");
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }

        public static async Task RunTimeout()
        {
            var joe = CreateMessenger("Joe", 10);
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(5));

            try
            {
                await foreach (var item in joe.ReadAllAsync(cts.Token))
                    Console.WriteLine(item);

                Console.WriteLine("Joe sent all of his messages.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Joe, you are too slow!");
            }

        }

        public static async Task RunQuitChannel()
        {
            var cts = new CancellationTokenSource();
            var joe = CreateMessenger("Joe", 10, cts.Token);
            cts.CancelAfter(TimeSpan.FromSeconds(5));

            await foreach (var item in joe.ReadAllAsync())
                WriteLineWithTime(item);

        }

        public static async Task RunWebSearch()
        {
            var ch = Channel.CreateUnbounded<string>();

            async Task Search(string source, string term, CancellationToken token)
            {
                await Task.Delay(TimeSpan.FromSeconds(new Random().Next(5)), token);
                await ch.Writer.WriteAsync($"Result from {source} for {term}", token);
            }

            var term = "Jupyter";
            var token = new CancellationTokenSource(TimeSpan.FromSeconds(3)).Token;

            var search1 = Search("Wikipedia", term, token);
            var search2 = Search("Quora", term, token);
            var search3 = Search("Everything2", term, token);

            try
            {
                
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(await ch.Reader.ReadAsync(token));
                }

                Console.WriteLine("All searches have completed.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Timeout.");
            }

            ch.Writer.Complete();
        }

        private static ChannelReader<string> CreateMessenger(string msg, int count)
        {
            var ch = Channel.CreateUnbounded<string>();
            var rnd = new Random();

            Task.Run(async () =>
            {
                for (int i = 0; i < count; i++)
                {
                    await ch.Writer.WriteAsync($"{msg} {i}");
                    await Task.Delay(TimeSpan.FromSeconds(rnd.Next(3)));
                }
                ch.Writer.Complete();
            });

            return ch.Reader;
        }

        private static ChannelReader<string> CreateMessenger(string msg, int count = 5, CancellationToken token = default(CancellationToken))
        {
            var ch = Channel.CreateUnbounded<string>();
            var rnd = new Random();

            Task.Run(async () =>
            {
                for (int i = 0; i < count; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        await ch.Writer.WriteAsync($"{msg} says bye!");
                        break;
                    }

                    await ch.Writer.WriteAsync($"{msg} {i}");
                    await Task.Delay(TimeSpan.FromSeconds(rnd.Next(3)));
                }
                ch.Writer.Complete();
            });

            return ch.Reader;
        }

        private static ChannelReader<T> Merge<T>(params ChannelReader<T>[] inputs)
        {
            var output = Channel.CreateUnbounded<T>();

            Task.Run(async () =>
            {
                async Task Redirect(ChannelReader<T> input)
                {
                    await foreach (var item in input.ReadAllAsync())
                        await output.Writer.WriteAsync(item);
                                       
                }
                
                await Task.WhenAll(inputs.Select(i => Redirect(i)).ToArray());
                
                output.Writer.Complete();
            });

           

            return output;
        }

        private static IList<ChannelReader<T>> Split<T>(ChannelReader<T> ch, int n)
        {
            var outputs = new Channel<T>[n];

            for (int i = 0; i < n; i++)
                outputs[i] = Channel.CreateUnbounded<T>();

            Task.Run(async () =>
            {
                var index = 0;
                await foreach (var item in ch.ReadAllAsync())
                {
                    await outputs[index].Writer.WriteAsync(item);
                    index = (index + 1) % n;
                }

                foreach (var ch in outputs)
                    ch.Writer.Complete();
            });

            return outputs.Select(ch => ch.Reader).ToArray();
        }
    }
}
