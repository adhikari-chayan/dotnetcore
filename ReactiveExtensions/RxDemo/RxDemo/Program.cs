using System;

namespace RxDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //using Observable

            //var evenNumber = new EvenNumberObservable();
            //var consoleObserver = new ConsoleLogObserver();
            //evenNumber.Subscribe(consoleObserver);


            //using Subject

            var evenNumberSubject = new EvenNumberSubject();
            evenNumberSubject.Subscribe(Console.WriteLine);
            evenNumberSubject.Run();

            Console.WriteLine("Completed!!");
            Console.ReadLine();
        }
    }
}
