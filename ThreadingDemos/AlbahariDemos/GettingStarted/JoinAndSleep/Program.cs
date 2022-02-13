using System;
using System.Threading;

namespace JoinAndSleep
{
    //This prints “y” 1,000 times, followed by “Thread t has ended!” immediately afterward.You can include a timeout when calling Join, either in milliseconds or as a TimeSpan. It then returns true if the thread ended or false if it timed out.

    //While waiting on a Sleep or Join, a thread is blocked and so does not consume CPU resources.
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Go);
            t.Start();
            t.Join();
            Console.WriteLine("Thread t has ended!");
        }

        static void Go()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }
    }
}
