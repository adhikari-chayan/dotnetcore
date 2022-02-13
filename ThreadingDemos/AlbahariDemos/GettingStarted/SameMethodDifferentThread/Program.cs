using System;
using System.Threading;

namespace SameMethodDifferentThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Thread(Go).Start();
            Go();
        }

        static void Go()
        {
            // Declare and use a local variable - 'cycles'
            for (int cycles = 0; cycles < 5; cycles++) Console.Write('?');
        }
    }
}
