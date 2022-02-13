using System;
using System.Threading;

namespace ThreadSync.MonitorDemo
{
    class Program
    {
        private static object _locker = new object();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(DoWork).Start();
            }

            Console.ReadKey();
        }

        public static void DoWork()
        {
            try
            {
                Monitor.Enter(_locker);

                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting");
                Thread.Sleep(2000);

                throw new Exception("Test Exception");
                
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed");

                
            }
            catch(Exception e)
            {
                //error logging
            }
            finally
            {
                Monitor.Exit(_locker);
            }
            
        }
    }
}
