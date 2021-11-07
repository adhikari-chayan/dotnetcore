using System;
using static RxDemo.DataFlow.FavourtiteGameProcessor;

namespace RxDemo.DataFlow
{
    class Program
    {
        private static readonly FavourtiteGameProcessor _favouriteGameProcessor = new FavourtiteGameProcessor();

        private static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
            var userId = rnd.Next(1, 100).ToString();
            var gameId = $"Game-{userId}";
            OpenGame(userId, gameId);
            Console.ReadKey();
        }

        private static void OpenGame(string userId, string gameId)
        {
            _favouriteGameProcessor.Publish(new FavouriteGame
            {
                GameId = gameId,
                UserId = userId
            });

            Console.WriteLine($"Open the game {gameId}");
        }
    }
}
