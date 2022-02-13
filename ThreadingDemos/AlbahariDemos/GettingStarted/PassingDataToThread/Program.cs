using System;
using System.Threading;

namespace PassingDataToThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The easiest way to pass arguments to a thread’s target method is to execute a lambda expression that calls the method with the desired arguments
            Thread t1 = new Thread(() => Print("Hello from t1!"));
            t1.Start();


            //You can even wrap the entire implementation in a multi-statement lambda
            new Thread(() =>
            {
                Console.WriteLine("I'm running on another thread!");
                Console.WriteLine("This is so easy!");
            }).Start();


            //Another technique is to pass an argument into Thread’s Start method
            Thread t2 = new Thread(PrintObj);
            t2.Start();
        }

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static void PrintObj(object messageObj)
        {
            string message = (string)messageObj;   // We need to cast here
            Console.WriteLine(message);
        }
    }
}
