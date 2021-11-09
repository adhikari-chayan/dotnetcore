using System;
using System.Threading;

namespace ThreadSync.SemaphoreDemo
{
    class Program
    {
        static Semaphore _semaphore = new Semaphore(2,2);//This tells us how many threads we can run in parallel. In this case 2 threads are writing together
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }

           

            Console.ReadKey();
        }

        public static void Write()
        {

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");

            _semaphore.WaitOne();

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing...");

            //Emulating writing to a common resource
            Thread.Sleep(5000);

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing Completed....");

            _semaphore.Release();
            

        }
    }
}
