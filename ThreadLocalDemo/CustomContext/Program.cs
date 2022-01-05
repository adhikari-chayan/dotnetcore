using System;
using System.Threading;

namespace CustomContext
{
    /// <summary>
    /// I simulate the behavior of a Web server, listening for requests (in this case, listening for keyboard input). If there is no request, the server program will block. If there is a request (keyboard input in this case), the server will respond to the request, generate the current request context, and generate a TLS variable, and then execute the Execute function (equivalent to HttpContext flowing into the processing pipe) Finally, clear the value in the TLS variable, because the thread is a thread in the thread pool and will be reused to process other requests. If TLS is not cleared, dirty data will be generated.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var name = Console.ReadLine();

                ThreadPool.QueueUserWorkItem(state =>
                {
                    Console.WriteLine($"Request:{name} will be handled by Thread {Thread.CurrentThread.ManagedThreadId} and has been queued in Threadpool");

                    new ConsoleContext(name);

                    Execute();

                    ConsoleContext.ResetContext();
                });
            }

            Console.ReadKey();
        }

        public static void Execute()
        {
            //Thread.Sleep(1000 * new Random(DateTime.Now.Millisecond).Next(5, 10));
            Thread.Sleep(10000);

            Console.WriteLine("Executing PrintName() method");

            PrintName();
        }

        public static void PrintName()
        {
            var name = ConsoleContext.Current.ConsoleName;
            
            Console.WriteLine($"Current managed thread ID: {Thread.CurrentThread.ManagedThreadId} name: {name}");
        }
    }
}
