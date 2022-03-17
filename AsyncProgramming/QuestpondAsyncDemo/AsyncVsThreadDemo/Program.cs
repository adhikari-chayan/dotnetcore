using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncVsThreadDemo
{
    //https://www.youtube.com/watch?v=G3tz9rxts8E&t=1268s
    class Program
    {
        static void Main(string[] args)
        {
            Print("Code 1");
            Print("Code 2");
            SomeMethod();
            Print("Code 7");
            Print("Code 8");
            Console.ReadKey();
        }

        static async void SomeMethod()
        {
            Print("Code 3");
            Print("Code 4");
            
            await Task.Delay(30000);

            Print("Code 5");
            Print("Code 6");
        }

        static void Print(string text)
        {
            Console.WriteLine($"{text} - {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
