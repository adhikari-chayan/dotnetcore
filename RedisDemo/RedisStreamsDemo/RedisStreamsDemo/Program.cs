//https://developer.redis.com/develop/dotnet/streams/stream-basics/
using StackExchange.Redis;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;

var muxer = ConnectionMultiplexer.Connect("localhost");
var db = muxer.GetDatabase();

const string streamName = "telemetry";
const string groupName = "avg";

Console.Write("Enter number of consumenrs in Consumer group: ");
int n = Convert.ToInt32(Console.ReadLine());
var consumers = new List<string>();

for(int i = 0; i < n; i++)
{
    consumers.Add($"avg-{i+1}");
}

if(!(await db.KeyExistsAsync(streamName)) || 
   (await db.StreamGroupInfoAsync(streamName)).All(x => x.Name != groupName))
{
    await db.StreamCreateConsumerGroupAsync(streamName, groupName, "0-0", true);
}

//This Task will write a random number between 50 and 65 as the temp and send the current time as the time.
var producerTask = Task.Run(async () =>
{
    var random = new Random();
    while (!token.IsCancellationRequested)
    {
        await db.StreamAddAsync(streamName, new NameValueEntry[] { new("temp", random.Next(50, 65)), new NameValueEntry("time", DateTimeOffset.Now.ToUnixTimeSeconds()) });

        await Task.Delay(2000);
    }
});

Dictionary<string, string> ParseResult(StreamEntry entry) => entry.Values.ToDictionary(x => x.Name.ToString(), x => x.Value.ToString());

#region Most Recent Element Task
//Spin up most recent element task
//o do this, we'll use the StreamRangeAsync method passing in two special ids, - which means the lowest id, and +, which means the highest id. Running this command will result in some duplication. This redundancy is necessary because the StackExchange.Redis library does not support blocking stream reads and does not support the special $ character for stream reads.

//var readTask = Task.Run(async () =>
//{
//    while (!token.IsCancellationRequested)
//    {
//        var result = await db.StreamRangeAsync(streamName, "-", "+", 1, Order.Descending);
//        if (result.Any())
//        {
//            var dict = ParseResult(result.First());
//            Console.WriteLine($"Read result: temp {dict["temp"]} time: {dict["time"]}");
//        }

//        await Task.Delay(1000);
//    }
//});
#endregion


//Spin up consumer group read Task

double count = default;
double total = default;

var allTasks = consumers.Select(CreateConsumerTask).ToList();
allTasks.Add(producerTask);

Task CreateConsumerTask(string consumerName)
{
    return Task.Run(async () =>
    {
        string id = string.Empty;
        while (!token.IsCancellationRequested)
        {
            if (!string.IsNullOrEmpty(id))
            {
                await db.StreamAcknowledgeAsync(streamName, groupName, id);
                id = string.Empty;
            }
            var result = await db.StreamReadGroupAsync(streamName, groupName, consumerName, ">", 1);
            if (result.Any())
            {
                id = result.First().Id;
                count++;
                var dict = ParseResult(result.First());
                total += double.Parse(dict["temp"]);
                Console.WriteLine($"Group read result: temp: {dict["temp"]}, time: {dict["time"]}, current average: {total / count:00.00} from {consumerName}");
            }

            await Task.Delay(1000);
        }
    });
}

#region Understanding
//var consumerGroupReadTask1 = Task.Run(async () =>
//{

//    string id = string.Empty;
//    while (!token.IsCancellationRequested)
//    {
//        //We'll check to see if we have a recent message-id to handle all of this. If we do, we will send an acknowledgment to the server that the id was processed. Then we will grab the next message to be processed from the stream, pull out the data and the id and print out the result.

//        if (!string.IsNullOrEmpty(id))
//        {
//            await db.StreamAcknowledgeAsync(streamName, groupName, id);
//            id = string.Empty;
//        }
//        var result = await db.StreamReadGroupAsync(streamName, groupName, "avg-1", ">", 1);
//        if (result.Any())
//        {
//            id = result.First().Id;
//            count++;
//            var dict = ParseResult(result.First());
//            total += double.Parse(dict["temp"]);
//            Console.WriteLine($"Group read result: temp: {dict["temp"]}, time: {dict["time"]}, current average: {total / count:00.00} - from avg-1");
//        }

//        await Task.Delay(1000);
//    }
//});


//var consumerGroupReadTask2 = Task.Run(async () =>
//{
//    string id = string.Empty;
//    while (!token.IsCancellationRequested)
//    {
//        if (!string.IsNullOrEmpty(id))
//        {
//            await db.StreamAcknowledgeAsync(streamName, groupName, id);
//            id = string.Empty;
//        }
//        var result = await db.StreamReadGroupAsync(streamName, groupName, "avg-2", ">", 1);
//        if (result.Any())
//        {
//            id = result.First().Id;
//            count++;
//            var dict = ParseResult(result.First());
//            total += double.Parse(dict["temp"]);
//            Console.WriteLine($"Group read result: temp: {dict["temp"]}, time: {dict["time"]}, current average: {total / count:00.00} from avg-2");
//        }

//        await Task.Delay(1000);
//    }
//});
#endregion

tokenSource.CancelAfter(TimeSpan.FromSeconds(20));
//await Task.WhenAll(producerTask, consumerGroupReadTask1, consumerGroupReadTask2);
await Task.WhenAll(allTasks);
