using System;
using System.Collections.Generic;
using System.Threading;

namespace ReaderWriterLockSlimDemo
{
    //Quite often, instances of a type are thread-safe for concurrent read operations, but not for concurrent updates (nor for a concurrent read and update). This can also be true with resources such as a file. Although protecting instances of such types with a simple exclusive lock for all modes of access usually does the trick, it can unreasonably restrict concurrency if there are many readers and just occasional updates.

    //An example of where this could occur is in a business application server, where commonly used data is cached for fast retrieval in static fields.

    //When compared to an ordinary lock (Monitor.Enter/Exit), ReaderWriterLockSlim is twice as slow, though.

    //With both classes, there are two basic kinds of lock — a read lock and a write lock:

    //A write lock is universally exclusive.
    //A read lock is compatible with other read locks.
    //So, a thread holding a write lock blocks all other threads trying to obtain a read or write lock (and vice versa). But if no thread holds a write lock, any number of threads may concurrently obtain a read lock.
    internal class Program
    {
        static ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
        static List<int> _items = new List<int>();
        static Random _rand = new Random();
        static void Main(string[] args)
        {
            new Thread(Read).Start();
            new Thread(Read).Start();
            new Thread(Read).Start();

            new Thread(Write).Start("A");
            new Thread(Write).Start("B");
        }

        static void Read()
        {
            while (true)
            {
                
                _rw.EnterReadLock();
                foreach (int i in _items) Thread.Sleep(10);
                _rw.ExitReadLock();
            }
        }

        static void Write(object threadID)
        {
            while (true)
            {
                Console.WriteLine(_rw.CurrentReadCount + " concurrent readers");
                int newNumber = GetRandNum(100);
                _rw.EnterWriteLock();
                _items.Add(newNumber);
                _rw.ExitWriteLock();
                Console.WriteLine("Thread " + threadID + " added " + newNumber);
                Thread.Sleep(100);
            }
        }

        static int GetRandNum(int max) { lock (_rand) return _rand.Next(max); }
    }
}
