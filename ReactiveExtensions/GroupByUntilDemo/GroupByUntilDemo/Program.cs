using System;
using System.Reactive.Linq;
using System.Reactive.Concurrency;


namespace GroupByUntilDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //*****************************************************************************************//
            //*** Generate a sequence of random integers less than 100 every seconds continuously.  ***//
            //*****************************************************************************************//

            Random rand = new Random();

            var obs = Observable.Generate(rand.Next(100),// Initial value
                                          x => true,// The termination condition. Never terminate.
                                          x => rand.Next(100),// Iteration step function 
                                          x => x,// Selector function 
                                          x => TimeSpan.FromMilliseconds(500), // timeSelector Delay function
                                          Scheduler.ThreadPool);// Schedule on a .NET threadpool thread


            //obs.Subscribe(x => Console.WriteLine(x));

            //*************************************************************************************//
            //*** Generate a groups of the random integers in the sequence that are in the 80s. ***//
            //*** Each grouping has an expiration set to expire in 10 seconds. This is set by   ***//
            //*** the durationSelector function which returns an observable sequence of time    ***//
            //*** spans set to 10 seconds.                                                      ***//
            //*************************************************************************************//

            int groupExpirationSec = 10;

            var obsEighties = obs.GroupByUntil(x => (x > 79) && (x < 90),
                                               x => x,
                                               x => Observable.Timer(TimeSpan.FromSeconds(groupExpirationSec)))
                                 .Subscribe(OnNewSequence);

            Console.ReadLine();

          


        }

        //*************************************************************************************//
        //*** Subscribe to the grouped sequences. Each grouped sequence will expire after   ***//
        //*** 10 seconds by completing the sequence. Display timings with the sequence so   ***//
        //*** this is evident.                                                              ***//
        //*************************************************************************************//

        private static void OnNewSequence(IGroupedObservable<bool, int> groupedObs)
        {
            int groupExpirationSec = 10;
            if (groupedObs.Key == true) // True for eighties group
            {
                Console.WriteLine("\nNew eighties group\nThis group should expire at {0}\n",
                                  (DateTime.Now + TimeSpan.FromSeconds(groupExpirationSec)).ToLongTimeString());

                groupedObs.Subscribe(x => Console.WriteLine(x),
                                     () => Console.WriteLine("\nGrouped sequence completed or expired. {0}\n",
                                                             DateTime.Now.ToLongTimeString()));
            }
       

           
        }
    }
}
