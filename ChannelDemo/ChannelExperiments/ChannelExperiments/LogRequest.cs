namespace ChannelExperiments;

public class LogRequest
{
    public LogLevel Level { get; set; }

    public string Message { get; set; }

    public string? Details { get; set; }
}

public enum LogLevel
{
    Fatal,
    Error,
    Warn,
    Info,
    Debug,
    Trace,
}