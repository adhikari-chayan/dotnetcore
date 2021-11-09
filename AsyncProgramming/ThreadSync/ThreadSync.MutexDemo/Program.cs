using System;
using System.Threading;

namespace ThreadSync.MutexDemo
{
    class Program
    {
        static Mutex _mutex = new Mutex();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }

            //throws exception Object synchronization method was called from an unsynchronized block of code. 
            Thread.Sleep(3000);
            _mutex.ReleaseMutex();

            Console.ReadKey();
        }

        public static void Write()
        {

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");

            _mutex.WaitOne();

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing...");

            //Emulating writing to a common resource
            Thread.Sleep(5000);

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing Completed....");


            _mutex.ReleaseMutex();

        }
    }
}
