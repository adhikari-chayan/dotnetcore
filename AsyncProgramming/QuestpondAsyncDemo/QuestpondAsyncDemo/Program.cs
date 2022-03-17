using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        //https://www.youtube.com/watch?v=8Je1W82vwYM

        static void Main(string[] args)
        {
            //if async methods are not awaited execution of the current Main method continues before the call is completed

            //Async does not immidiately create new thread. there is only  ONE thread which is time slicing between tasks

            //For the code after await Task.Delay, a new thread is spawn and is executed on this new thread 

            Console.WriteLine($"MainAsync is running on thread {Thread.CurrentThread.ManagedThreadId}");

            NewMethod1();
            
            NewMethod2();

            //running the units parallely using TPL
            //Task.Factory.StartNew(NewMethod1);
            //Task.Factory.StartNew(NewMethod2);
            
            Console.WriteLine($"Start data input, enter your name in thread {Thread.CurrentThread.ManagedThreadId} ");
            string str = Console.ReadLine();
            Console.WriteLine(str);
            Console.Read();
        }

        private static async Task NewMethod1()
        {
            Console.WriteLine($"NewMethod1 starts running on thread  {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(10000);//downloading file 1
            
            
            Console.WriteLine($"Downloaded file1 by thread {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task NewMethod2()
        {
            Console.WriteLine($"NewMethod2 starts running on thread  {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(10000);//downloading file2
           
            Console.WriteLine($"Downloaded file2 by thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
