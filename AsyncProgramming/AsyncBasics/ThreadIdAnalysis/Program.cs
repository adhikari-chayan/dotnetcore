using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadIdAnalysis
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Thread.CurrentThread.ManagedThreadId.Dump("1");
            var client = new HttpClient();
            Thread.CurrentThread.ManagedThreadId.Dump("2");
            var getStringTask = client.GetStringAsync("http://google.com");
            Thread.CurrentThread.ManagedThreadId.Dump("3");

            int a = 0;
           
            /*
             If GetStringAsync (and therefore getStringTask) completes before the Main method awaits it, control remains in Main method(in this case the line after the await statement is not executed by a separate thread). The expense of suspending and then returning to Main would be wasted if the called asynchronous process getStringTask has already completed and Main doesn't have to wait for the final result.
             */
            for (int i = 0; i < int.MaxValue; i++)
            {
                a += i;
            }

            //for(int i = 0; i < 10000; i++)
            //{
            //    a += i;
            //}


            Thread.CurrentThread.ManagedThreadId.Dump("4");
            var page = await getStringTask;
            Thread.CurrentThread.ManagedThreadId.Dump("5");
        }
    }

    public static class StringExtensions
    {
        public static void Dump(this int threadId, string message)
        {            
            Console.WriteLine(message);
            Console.WriteLine(threadId);
            Console.WriteLine("------");
        }
    }
}
