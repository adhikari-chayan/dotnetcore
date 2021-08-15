using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using OrderHandler.Core;
using System.Threading;
using System.Threading.Tasks;

namespace OrderHandler.WebApi.StartupTasks
{
    public class KafkaTopicCreator : IHostedService
    {
        private readonly AdminClientConfig _adminClientConfig;
        public KafkaTopicCreator(AdminClientConfig adminClientConfig)
        {
            _adminClientConfig = adminClientConfig;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await KafkaHelper.CreateTopicAsync(_adminClientConfig, ApplicationConstants.OrderRequestsTopicName, 1);
           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
