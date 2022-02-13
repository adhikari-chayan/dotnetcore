using System;
using System.Threading;

namespace SemaphoreDemo
{
    //A semaphore is like a nightclub: it has a certain capacity, enforced by a bouncer. Once it’s full, no more people can enter, and a queue builds up outside. Then, for each person that leaves, one person enters from the head of the queue. The constructor requires a minimum of two arguments: the number of places currently available in the nightclub and the club’s total capacity.

    //A semaphore with a capacity of one is similar to a Mutex or lock, except that the semaphore has no “owner” — it’s thread-agnostic.Any thread can call Release on a Semaphore, whereas with Mutex and lock, only the thread that obtained the lock can release it

    //There are two functionally similar versions of this class: Semaphore and SemaphoreSlim. The latter was introduced in Framework 4.0 and has been optimized to meet the low-latency demands of parallel programming. It’s also useful in traditional multithreading because it lets you specify a cancellation token when waiting. It cannot, however, be used for interprocess signaling.

    //Semaphore incurs about 1 microsecond in calling WaitOne or Release; SemaphoreSlim incurs about a quarter of that.

    internal class Program
    {
        //Semaphores can be useful in limiting concurrency — preventing too many threads from executing a particular piece of code at once. In the following example, five threads try to enter a nightclub that allows only three threads in at once:

        static SemaphoreSlim _sem = new SemaphoreSlim(3); // Capacity of 3
        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++) 
            { 
                new Thread(Enter).Start(i); 
            }
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            _sem.Wait();
            Console.WriteLine(id + " is in!");           // Only three threads
            Thread.Sleep(1000 * (int)id);               // can be here at
            Console.WriteLine(id + " is leaving");       // a time.
            _sem.Release();
        }

        //If the Sleep statement was instead performing intensive disk I/O, the Semaphore would improve overall performance by limiting excessive concurrent hard-drive activity.

        //A Semaphore, if named, can span processes in the same way as a Mutex.
    }
}
