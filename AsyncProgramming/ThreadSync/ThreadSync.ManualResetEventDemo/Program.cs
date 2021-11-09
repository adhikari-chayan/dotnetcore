using System;
using System.Threading;

namespace ThreadSync.ManualResetEventDemo
{
    class Program
    {
        //When one thread signals all waiting threads start automatically 

        static ManualResetEvent _mre = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            //Starting writer thread
            new Thread(Write).Start();

            for (int i = 0; i < 5; i++)
            {
                new Thread(Read).Start();
            }
            Console.ReadKey();
        }

        public static void Read()
        {
           
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");
            _mre.WaitOne();//This blocks the thread till it gets a signal from the MRE. The signal comews when _mre.Set is called
            
           Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Reading...");
            
            //Logic to access and read the common resource
            
        }

        public static void Write()
        {

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing...");

            _mre.Reset();

            //Emulating writing to a common resource
            Thread.Sleep(5000);
            
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing Completed....");
            
            _mre.Set();

        }
    }
}
