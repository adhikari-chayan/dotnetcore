using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadSafeWithLocking
{
    internal class Program
    {
        //Two threads simultaneously add an item to the same List collection, then enumerate the list

        static List<string> _list = new List<string>();
        static void Main()
        {
            new Thread(AddItem).Start();
            new Thread(AddItem).Start();
        }

        static void AddItem()
        {
            lock (_list)
            {
                _list.Add("Item " + _list.Count);
            }

            //Enumerating.NET collections is also thread-unsafe in the sense that an exception is thrown if the list is modified during enumeration.Rather than locking for the duration of enumeration, in this example we first copy the items to an array.This avoids holding the lock excessively if what we’re doing during enumeration is potentially time - consuming.

            string[] items;
            lock (_list)
            { 
                items = _list.ToArray(); 
            }
            foreach (string s in items) Console.WriteLine(s);
        }
    }
}
