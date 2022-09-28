
using ChannelExperiments;
using Microsoft.Extensions.DependencyInjection;

var container = Startup.ConfigureService();

var logger = container.GetRequiredService<IRemoteLogger>();

var t1= Task.Run( async() =>  await logger.Log(LogLevel.Info, "Test Info Message"));

var t2 = Task.Run(async () => await logger.Log(LogLevel.Warn, "Test Warn Message"));

var t3 = Task.Run(async () => await logger.Log(LogLevel.Error, "Test Error Message"));

await Task.WhenAll(t1, t2, t3);

Console.WriteLine("Program completed");

Console.ReadKey();