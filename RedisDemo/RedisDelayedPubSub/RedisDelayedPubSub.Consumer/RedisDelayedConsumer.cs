using System;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Redis;



namespace RedisDelayedPubSub.Consumer
{
    internal class RedisDelayedConsumer
    {
        private readonly IDatabase db;
        private readonly ConnectionMultiplexer redis;
        private readonly AutoResetEvent waitLock = new AutoResetEvent(true);



        public RedisDelayedConsumer()
        {
            redis = ConnectionMultiplexer.Connect("localhost");
            db = redis.GetDatabase();
        }


        public async Task Subscribe(CancellationToken token)
        {
            var sub = redis.GetSubscriber();



            await sub.SubscribeAsync("signals", (_, _) =>
            {
                //Console.WriteLine($"Received signal: {message.ToString()}");
                waitLock.Set();
            });

            Task.Run(() => ProcessMessages(token));
        }



        private async Task ProcessMessages(CancellationToken token)
        {
            const int batchAmount = 2;
            while (WaitHandle.WaitAny(new[] { waitLock, token.WaitHandle }) == 0)
            {
                var messages = await db.StreamReadGroupAsync("signalsStream",
                "signalsGroup",
                $"app:{DateTime.UtcNow.ToFileTime()}",
                ">",
                batchAmount,
                true);
                var count = messages.Length;



                foreach (var message in messages)
                {
                    var keyValue = message.Values[0];
                    var key = keyValue.Name.ToString();
                    var value = keyValue.Value.ToString();
                    var valueDate = DateTime.FromFileTime(long.Parse(value));
                    var delay = DateTime.Now - valueDate;
                    Console.WriteLine($"Received key:'{key}' at {DateTime.UtcNow} sent at {valueDate} with delay: {delay}");



                    var actualKey = key.Split(":")[1];
                    if (actualKey.StartsWith("md"))
                    {
                        var taskSleep = int.Parse(actualKey.Substring(2));
                        Console.WriteLine($"Start delay for: {taskSleep}");
                        await Task.Delay(taskSleep * 1000);
                    }
                }



                if (count == batchAmount)
                {
                    waitLock.Set();
                }
            }
        }
    }
}