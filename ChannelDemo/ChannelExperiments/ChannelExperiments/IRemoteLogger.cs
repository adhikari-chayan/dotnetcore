using System.Threading.Tasks;

namespace ChannelExperiments;

public interface IRemoteLogger
{
    public Task Log(LogLevel level, string message, string details = null);
}