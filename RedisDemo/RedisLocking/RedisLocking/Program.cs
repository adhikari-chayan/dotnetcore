using StackExchange.Redis;
using System;

namespace RedisLocking
{
    class Program
    {
        public static ConnectionMultiplexer Connection => lazyConnection.Value;
        static void Main(string[] args)
        {
            var db = Connection.GetDatabase();
            Console.WriteLine("Enter Key: ");
            var key = Console.ReadLine();
            var lockKey = $"{key}_lock";
            var lockToken = Guid.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(60);
            if (db.LockTake(lockKey,lockToken,duration))
            {
                try
                {
                    Console.WriteLine($"value: {db.StringGet(key)}");
                }
                finally
                {
                    db.LockRelease(lockKey, lockToken);
                }
            }
            else
            {
                Console.WriteLine("Unable to acquire lock");
            }

            Console.ReadKey();
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            ConfigurationOptions configuration = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                ConnectTimeout = 20000,
            };

            configuration.EndPoints.Add("localhost", 6379);

            return ConnectionMultiplexer.Connect(configuration.ToString());
        });

        
        
    }
}
