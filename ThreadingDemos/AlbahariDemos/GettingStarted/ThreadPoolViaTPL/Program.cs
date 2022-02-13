using System;
using System.Threading.Tasks;

namespace ThreadPoolViaTPL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pooled threads are always background threads (this is usually not a problem).
            Task.Factory.StartNew(Go);

            // Start the task executing:
            Task<string> task = Task.Factory.StartNew(() => DownloadString("http://www.linqpad.net"));

            // We can do other work here and it will execute in parallel:
            RunSomeOtherMethod();

            // When we need the task's return value, we query its Result property:
            // If it's still executing, the current thread will now block (wait)
            // until the task finishes:
            string result = task.Result;

            //Any unhandled exceptions are automatically rethrown when you query the task's Result property, wrapped in an AggregateException. However, if you fail to query its Result property (and don’t call Wait) any unhandled exception will take the process down.
        }

        private static void RunSomeOtherMethod()
        {
            
        }

        static void Go()
        {
            Console.WriteLine("Hello from the thread pool!");
        }

        static string DownloadString(string uri)
        {
            using (var wc = new System.Net.WebClient())
                return wc.DownloadString(uri);
        }
    }
}
