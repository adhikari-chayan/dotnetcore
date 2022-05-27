using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Notifications;
using StackExchange.Redis;

var connection = ConnectionMultiplexer.Connect("localhost");

for (var i = 0; i < 10; i++)
{
    connection.GetSubscriber().Publish("PostCreated",
                                       JsonConvert.SerializeObject(new PostAddedNotification
                                                                   {
                                                                       PostId = i + 1
                                                                   },
                                                                   new JsonSerializerSettings
                                                                   {
                                                                       ContractResolver = new DefaultContractResolver
                                                                                          {
                                                                                              NamingStrategy = new CamelCaseNamingStrategy()
                                                                                          },
                                                                   }));

    Console.WriteLine($"Post {i} published.");
}

Console.ReadKey();