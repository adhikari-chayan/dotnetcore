using System;
using System.Threading;

namespace CapturedVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You must be careful about accidentally modifying captured variables after starting the thread, because these variables are shared

            //The output is nondeterministic! Here’s a typical result

            //The problem is that the i variable refers to the same memory location throughout the loop’s lifetime. Therefore, each thread calls Console.Write on a variable whose value may change as it is running
            for (int i = 0; i < 10; i++)
                new Thread(() => Console.Write(i)).Start();

            //The solution is to use a temporary variable as follows

            //Variable temp is now local to each loop iteration. Therefore, each thread captures a different memory location and there’s no problem.
            for (int i = 0; i < 10; i++)
            {
                int temp = i;
                new Thread(() => Console.Write(temp)).Start();
            }

            //Another example
            string text = "t1";
            Thread t1 = new Thread(() => Console.WriteLine(text));

            text = "t2";
            Thread t2 = new Thread(() => Console.WriteLine(text));

            t1.Start();
            t2.Start();
        }
    }
}
