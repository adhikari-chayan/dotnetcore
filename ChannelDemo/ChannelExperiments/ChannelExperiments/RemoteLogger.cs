namespace ChannelExperiments;

public class RemoteLogger : IAsyncDisposable, IRemoteLogger
{
    private readonly ILogProcessingChannel logProcessingChannel;
    private bool isDisposed;
    private readonly CancellationTokenSource remoteLoggingCancellationTokenSource = new ();
    private readonly Task remoteLoggingTask;

    public RemoteLogger(ILogProcessingChannel logProcessingChannel)
    {
       
        this.logProcessingChannel = logProcessingChannel;
 

        remoteLoggingTask = Task.Run(async () => await LogRemoteData(remoteLoggingCancellationTokenSource.Token),
                                     remoteLoggingCancellationTokenSource.Token
                                    );
    }

    public async Task Log(LogLevel level, string message, string details = null)
        => await logProcessingChannel.AddLogRequest(new LogRequest
                                                    {
                                                        Level = level,
                                                        Message = message,
                                                        Details = details
                                                    },
                                                    remoteLoggingCancellationTokenSource.Token);

    public async ValueTask DisposeAsync()
    {
        if (isDisposed)
        {
            return;
        }

        remoteLoggingCancellationTokenSource.Cancel();
        remoteLoggingTask.Wait();

        remoteLoggingCancellationTokenSource.Dispose();
        remoteLoggingTask.Dispose();

        await logProcessingChannel.CompleteReader();

        isDisposed = true;
    }

    private async Task LogRemoteData(CancellationToken cancellationToken)
    {
        try
        {
            await foreach (var logRequest in logProcessingChannel.ReadAllLogRequests(cancellationToken))
            {
                await Task.Delay(5000);
                Console.WriteLine(logRequest.Message);
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation Cancelled");
        }
        
    }
}