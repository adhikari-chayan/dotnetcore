using System;
using System.Collections.Generic;
using System.Text;

namespace RxDemo
{
    class ConsoleLogObserver : IObserver<int>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"error: {error}");
        }

        public void OnNext(int value)
        {
            Console.WriteLine($"even number {value}");
        }
    }
}
