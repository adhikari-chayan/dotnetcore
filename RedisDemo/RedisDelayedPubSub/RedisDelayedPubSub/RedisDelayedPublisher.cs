using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisDelayedPubSub.Sender
{
    public class RedisDelayedPublisher
    {
        private readonly IDatabase db;

        public RedisDelayedPublisher()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            db = redis.GetDatabase();
        }

        public async Task Publish(string key, int delay)
        {
            var value = DateTime.Now.ToFileTime();
            var actualDelay = delay > 0 ? TimeSpan.FromSeconds(delay) : TimeSpan.FromMilliseconds(1);
            await db.StringSetAsync($"Delayed-Value:{key}", value, expiry: actualDelay.Add(TimeSpan.FromSeconds(5)));
            await db.StringSetAsync($"Delayed:{key}", value, expiry: actualDelay); 
            
            //DelayedSignal:BettingAnalytics(groupName):TransactionscopeId app name shoul be parametrized and read it from a config while instantiating the publisher

            //We can create Consumer groups one for each groupName(one for BPS, one for BLS etc) to ensure one consumer group handles signals for one group
        }
    }
}
