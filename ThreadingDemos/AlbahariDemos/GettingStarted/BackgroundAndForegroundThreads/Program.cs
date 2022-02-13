using System;
using System.Threading;

namespace BackgroundAndForegroundThreads
{
    //By default, threads you create explicitly are foreground threads. 
    //Foreground threads keep the application alive for as long as any one of them is running, whereas background threads do not. 
    //Once all foreground threads finish, the application ends, and any background threads still running abruptly terminate.
    internal class Program
    {
        //If this program is called with no arguments, the worker thread assumes foreground status and will wait on the ReadLine statement for the user to press Enter. Meanwhile, the main thread exits, but the application keeps running because a foreground thread is still alive.

        //On the other hand, if an argument is passed to Main(), the worker is assigned background status, and the program exits almost immediately as the main thread ends (terminating the ReadLine).
        static void Main(string[] args)
        {
           Thread worker = new Thread(() => Console.ReadLine());
            
            if(args.Length > 0) worker.IsBackground = true;
            worker.Start();
        }
    }

    /*When a process terminates in this manner, any finally blocks in the execution stack of background threads are circumvented. This is a problem if your program employs finally (or using) blocks to perform cleanup work such as releasing resources or deleting temporary files. To avoid this, you can explicitly wait out such background threads upon exiting an application. There are two ways to accomplish this:
                    1.If you’ve created the thread yourself, call Join on the thread.
                    2.If you’re on a pooled thread, use an event wait handle.
      In either case, you should specify a timeout, so you can abandon a renegade thread should it refuse to finish for some reason. This is your backup exit strategy: in the end, you want your application to close — without the user having to enlist help from the Task Manager!*/
}
