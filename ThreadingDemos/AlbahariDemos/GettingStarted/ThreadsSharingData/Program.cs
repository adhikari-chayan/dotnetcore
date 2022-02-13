using System;
using System.Threading;

namespace ThreadsSharingData
{
    //internal class Program
    //{
    //    bool done;
    //    static void Main(string[] args)
    //    {

    //        Program instance = new Program(); // Create a common instance
    //        new Thread(instance.Go).Start();

    //        instance.Go();

    //    }

    //    // Note that Go is now an instance method
    //    void Go()
    //    {
    //        if (!done) { done = true; Console.WriteLine("Done"); }
    //    }
    //}

    //The problem with below method is that one thread can be evaluating the if statement right as the other thread is executing the WriteLine statement — before it’s had a chance to set done to true. Hence, Done will be printed twice.

    internal class Program
    {
        static bool done; // Static fields are shared between all threads
        static void Main(string[] args)
        {
            new Thread(Go).Start();

            Go();

        }

        static void Go()
        {
            if (!done)
            {
                Console.WriteLine("Done");
                done = true;
            }
        }
    }
}
