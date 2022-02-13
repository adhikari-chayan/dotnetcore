using System;
using System.Threading;

namespace ThreadPoolWithoutTPL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(Go);
            ThreadPool.QueueUserWorkItem(Go, 123);
            Console.ReadLine();

            //ThreadPool.QueueUserWorkItem doesn’t provide an easy mechanism for getting return values back from a thread after it has finished executing.Asynchronous delegate invocations(asynchronous delegates for short) solve this, allowing any number of typed arguments to be passed in both directions. Furthermore, unhandled exceptions on asynchronous delegates are conveniently rethrown on the original thread(or more accurately, the thread that calls EndInvoke), and so they don’t need explicit handling.

            Func<string, int> method = Work;
            IAsyncResult cookie = method.BeginInvoke("test", null, null);
            //
            // ... here's where we can do other work in parallel...
            //
            int result = method.EndInvoke(cookie);
            Console.WriteLine("String length is: " + result);

        }

        static void Go(object data)   // data will be null with the first call.
        {
            Console.WriteLine("Hello from the thread pool! " + data);
        }

        static int Work(string s) { return s.Length; }
    }
}
