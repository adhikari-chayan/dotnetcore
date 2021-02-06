using StackExchange.Redis;
using System;

namespace RedisHash
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = RedisStore.RedisCache;

            var hashKey = "hashKey";

            HashEntry[] redisBookHash =
            {
                new HashEntry("title","Redis for .NET Developers"),
                new HashEntry("year",2016),
                new HashEntry("author","Taswar Bhatti")
            };

            redis.HashSet(hashKey, redisBookHash);

            if (redis.HashExists(hashKey, "year"))
            {
                var year = redis.HashGet(hashKey, "year"); //year is 2016
                Console.WriteLine(year);
            }

            var allHash = redis.HashGetAll(hashKey);

            //get all the items
            foreach (var item in allHash)
            {
                //output 
                //key: title, value: Redis for .NET Developers
                //key: year, value: 2016
                //key: author, value: Taswar Bhatti
                Console.WriteLine($"key : {item.Name}, value : {item.Value}");
            }

            //get all the values
            var values = redis.HashValues(hashKey);

            foreach (var val in values)
            {
                //output
                //Redis for .NET Developers
                //2016
                //Taswar Bhatti
                Console.WriteLine(val); 
            }

            //get all the keys
            var keys = redis.HashKeys(hashKey);

            foreach (var k in keys)
            {
                Console.WriteLine(k); //result = title, year, author
            }

            if (redis.HashExists(hashKey, "year"))
            {
                var year = redis.HashIncrement(hashKey, "year", 1); //year now becomes 2017
                Console.WriteLine(year);
                var year2 = redis.HashDecrement(hashKey, "year", 1.5); //year now becomes 2015.5

                Console.WriteLine(year2);
            }

            Console.ReadKey();

        }
    }
}
