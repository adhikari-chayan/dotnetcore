using System;
using System.Threading;

namespace LockingDemo
{  

    internal class Program
    {
        static void Main(string[] args)
        {

        }    
    }

    //This class is not thread-safe: if Go was called by two threads simultaneously, it would be possible to get a division-by-zero error, because _val2 could be set to zero in one thread right as the other thread was in between executing the if statement and Console.WriteLine.
    internal class ThreadUnsafe
    {
        static int _val1 = 1, _val2 = 1;
        static void Go()
        {
            if(_val2 != 0)
                Console.WriteLine(_val1/_val2);
            
            _val2 = 0;
        }
    }

    //Only one thread can lock the synchronizing object (in this case, _locker) at a time, and any contending threads are blocked until the lock is released. If more than one thread contends the lock, they are queued on a “ready queue” and granted the lock on a first-come, first-served basis

    //Exclusive locks are sometimes said to enforce serialized access to whatever’s protected by the lock, because one thread’s access cannot overlap with that of another. In this case, we’re protecting the logic inside the Go method, as well as the fields _val1 and _val2.

    //A thread blocked while awaiting a contended lock has a ThreadState of WaitSleepJoin.
    internal class ThreadSafe
    {
        static readonly object _locker = new object();
        static int _val1 = 1, _val2 = 1;

        static void Go()
        {
            lock (_locker)
            {
                if (_val2 != 0)
                    Console.WriteLine(_val1 / _val2);

                _val2 = 0;
            }
        }

    }

    internal class ThreadSafeWithMonitor
    {
        static readonly object _locker = new object();
        static int _val1 = 1, _val2 = 1;

        static void Go()
        {
            Monitor.Enter(_locker);
            try
            {
                if (_val2 != 0)
                    Console.WriteLine(_val1 / _val2);

                _val2 = 0;
            }
            finally
            {
                Monitor.Exit(_locker);
            }

            //There’s a subtle vulnerability in the above code, however. Consider the (unlikely) event of an exception being thrown within the implementation of Monitor.Enter, or between the call to Monitor.Enter and the try block (due, perhaps, to Abort being called on that thread — or an OutOfMemoryException being thrown). In such a scenario, the lock may or may not be taken. If the lock is taken, it won’t be released — because we’ll never enter the try/finally block. This will result in a leaked lock.

            //lockTaken is false after this method if (and only if) the Enter method throws an exception and the lock was not taken.

            bool lockTaken = false;
            try
            {
                Monitor.Enter(_locker, ref lockTaken);
                // Do your stuff...
            }
            finally 
            { 
                if (lockTaken) 
                    Monitor.Exit(_locker); 
            }
        }
    }
}
