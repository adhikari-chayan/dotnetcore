namespace ChannelExperiments;

public interface ILogProcessingChannel
{
    Task<bool> AddLogRequest(LogRequest item, CancellationToken cancellationToken);

    IAsyncEnumerable<LogRequest> ReadAllLogRequests(CancellationToken cancellationToken);

    Task CompleteReader();
}