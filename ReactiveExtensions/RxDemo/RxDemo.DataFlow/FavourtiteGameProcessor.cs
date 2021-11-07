using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace RxDemo.DataFlow
{
   public class FavourtiteGameProcessor
    {
        public class FavouriteGame
        {
            public string UserId { get; set; }
            public string GameId { get; set; }

        }

        private readonly BufferBlock<FavouriteGame> _queue;
        private readonly IObservable<FavouriteGame> _games;
        private const int ParallelDegree = -1;

        public FavourtiteGameProcessor()
        {
            _queue = new BufferBlock<FavouriteGame>(new DataflowBlockOptions { BoundedCapacity = ParallelDegree });

            _games = _queue.AsObservable();
            _games.Subscribe(FavouriteEvent);
        }

        public void Publish(FavouriteGame e)
        {
            try
            {
                _queue.Post(e);
            }
            catch (Exception)
            {

                Console.WriteLine("write error log");
            }
        }

        private void FavouriteEvent(FavouriteGame e)
        {
            try
            {
                //Add to recent games
                Thread.Sleep(10000);
                Console.WriteLine($"Add {e.GameId} to recent games");
            }
            catch (Exception)
            {

                Console.WriteLine("Handle Exception");
            }
        }
    }
}
