using Microsoft.Extensions.DependencyInjection;

namespace ChannelExperiments
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                           .AddSingleton<ILogProcessingChannel, LogProcessingChannel>()
                           .AddSingleton<IRemoteLogger, RemoteLogger>()
                           .BuildServiceProvider();

            return provider;
        }
    }
}
