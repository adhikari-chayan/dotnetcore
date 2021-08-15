using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.OrderProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var producerConfig = new ProducerConfig();
                    var consumerConfig = new ConsumerConfig();
                    var adminConfig = new AdminClientConfig();
                    IConfiguration configuration = hostContext.Configuration;

                    configuration.Bind(nameof(ProducerConfig), producerConfig);
                    configuration.Bind(nameof(ConsumerConfig), consumerConfig);
                    configuration.Bind(nameof(AdminClientConfig), adminConfig);


                    services.AddSingleton<ProducerConfig>(producerConfig);
                    services.AddSingleton<ConsumerConfig>(consumerConfig);
                    services.AddSingleton<AdminClientConfig>(adminConfig);


                    services.AddHostedService<OrderProcessingService>();
                   
                });
    }
}
