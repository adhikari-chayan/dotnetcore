using System;
using System.Threading;

namespace ThreadLocalDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadLocal<int> threadLocal = new ThreadLocal<int>();
           //In the main thread, the value of this variable is 1
            threadLocal.Value = 1;
            new Thread(() => Console.WriteLine($"managed thread  ID: {Thread.CurrentThread.ManagedThreadId} The values are:{threadLocal.Value++}")).Start();
            new Thread(() => Console.WriteLine($"managed thread  ID: {Thread.CurrentThread.ManagedThreadId} The values are:{threadLocal.Value++}")).Start();
            new Thread(() => Console.WriteLine($"managed thread  ID: {Thread.CurrentThread.ManagedThreadId} The values are:{threadLocal.Value++}")).Start();
            Console.WriteLine($"Main thread ID: {Thread.CurrentThread.ManagedThreadId} The values are:{threadLocal.Value}");

            Console.ReadKey();

        }
    }
}
