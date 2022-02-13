using System;
using System.Threading;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //The try/catch statement in this example is ineffective, and the newly created thread will be encumbered with an unhandled NullReferenceException. This behavior makes sense when you consider that each thread has an independent execution path.
            try
            {
                new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception!!");
            }
        }

        static void Go()
        {
            throw null;
        }

        //You need an exception handler on all thread entry methods in production applications — just as you do (usually at a higher level, in the execution stack) on your main thread. An unhandled exception causes the whole application to shut down. With an ugly dialog!
        static void GoFixed()
        {
            try
            {
                // ...
                throw null;    // The NullReferenceException will get caught below
                               // ...
            }
            catch (Exception ex)
            {
                // Typically log the exception, and/or signal another thread
                // that we've come unstuck
                // ...
            }
        }
    }
}
