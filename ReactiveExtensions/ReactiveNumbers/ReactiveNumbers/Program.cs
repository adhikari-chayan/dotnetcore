using System;
using System.Reactive.Linq;

namespace ReactiveNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            IObservable<long> numbers = Observable.Interval(TimeSpan.FromSeconds(1));
            
            numbers.Subscribe(num =>
            {
                Console.WriteLine(num);
            });
            
            Console.ReadKey();
        }
    }
}
