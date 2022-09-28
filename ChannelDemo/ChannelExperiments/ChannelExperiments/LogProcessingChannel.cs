using System.Threading.Channels;


namespace ChannelExperiments;
public class LogProcessingChannel : ILogProcessingChannel
{
    private const int MaxMessagesInChannel = 1000;
    private readonly Channel<LogRequest> channel;

    public LogProcessingChannel()
    {
        var options = new BoundedChannelOptions(MaxMessagesInChannel)
                      {
                          SingleWriter = false,
                          SingleReader = true
                      };

        channel = Channel.CreateBounded<LogRequest>(options);
    }

    public async Task<bool> AddLogRequest(LogRequest item, CancellationToken cancellationToken)
    {
        while (await channel.Writer.WaitToWriteAsync(cancellationToken))
        {
            if (channel.Writer.TryWrite(item))
            {
                return true;
            }
        }

        channel.Writer.TryComplete();
        return false;
    }

    public IAsyncEnumerable<LogRequest> ReadAllLogRequests(CancellationToken ct = default)
    => channel.Reader.ReadAllAsync(ct);

    public Task CompleteReader()
        => channel.Reader.Completion;
}