using System.Threading.Channels;

var myChannel = Channel.CreateUnbounded<int>();

for (int i = 0; i < 10; i++)
{
    await myChannel.Writer.WriteAsync(i);
    await Task.Delay(1000);
}

while (true)
{
    var item = await myChannel.Reader.ReadAsync();
    Console.WriteLine(item);
}