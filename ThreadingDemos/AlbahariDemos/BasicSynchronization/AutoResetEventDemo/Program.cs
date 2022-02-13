using System;
using System.Threading;

namespace AutoResetEventDemo
{
    //Event wait handles are used for signaling. Signaling is when one thread waits until it receives notification from another.

    //AutoResetEvent: Allows a thread to unblock once when it receives a signal from another
    //ManualResetEvent: Allows a thread to unblock indefinitely when it receives a signal from another (until reset)

    //A ManualResetEvent functions like an ordinary gate. Calling Set opens the gate, allowing any number of threads calling WaitOne to be let through. Calling Reset closes the gate. Threads that call WaitOne on a closed gate will block; when the gate is next opened, they will be released all at once. Apart from these differences, a ManualResetEvent functions like an AutoResetEvent.
    internal class Program
    {
        //An AutoResetEvent is like a ticket turnstile: inserting a ticket lets exactly one person through. The “auto” in the class’s name refers to the fact that an open turnstile automatically closes or “resets” after someone steps through. A thread waits, or blocks, at the turnstile by calling WaitOne (wait at this “one” turnstile until it opens), and a ticket is inserted by calling the Set method. If a number of threads call WaitOne, a queue builds up behind the turnstile.A ticket can come from any thread; in other words, any (unblocked) thread with access to the AutoResetEvent object can call Set on it to release one blocked thread.

        //In the following example, a thread is started whose job is simply to wait until signaled by another thread(main thread):

        static EventWaitHandle _waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            new Thread(Waiter).Start();
            Thread.Sleep(10000);                  // Pause for a second...
            _waitHandle.Set();                    // Wake up the Waiter.
        }

        static void Waiter()
        {
            Console.WriteLine("Waiting...");
            _waitHandle.WaitOne();                // Wait for notification
            Console.WriteLine("Notified");
        }

        //If Set is called when no thread is waiting, the handle stays open for as long as it takes until some thread calls WaitOne. This behavior helps avoid a race between a thread heading for the turnstile, and a thread inserting a ticket (“Oops, inserted the ticket a microsecond too soon, bad luck, now you’ll have to wait indefinitely!”). However, calling Set repeatedly on a turnstile at which no one is waiting doesn’t allow a whole party through when they arrive: only the next single person is let through and the extra tickets are “wasted.”

        //Calling Reset on an AutoResetEvent closes the turnstile (should it be open) without waiting or blocking.
    }
}
