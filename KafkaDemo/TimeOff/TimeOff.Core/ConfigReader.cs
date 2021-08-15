using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;

namespace TimeOff.Core
{
    public class ConfigReader
    {
        private readonly IConfiguration _configuration;

        public bool IsLocalEnvironment { get; }
        public ConfigReader(IConfiguration configuration)
        {
            _configuration = configuration;
            IsLocalEnvironment = Convert.ToBoolean(configuration[nameof(IsLocalEnvironment)]);
        }

        public ProducerConfig GetProducerConfig()
        {
            var config = _configuration.GetSection(nameof(ProducerConfig)).Get<ProducerConfig>();
            config.ClientId = Dns.GetHostName();

            return config;
        }

        public ConsumerConfig GetConsumerConfig()
        {
            var config = _configuration.GetSection(nameof(ConsumerConfig)).Get<ConsumerConfig>();
            // Read messages from start if no commit exists.
            config.AutoOffsetReset = AutoOffsetReset.Earliest;
            
            return config;
            

            
        }

        public AdminClientConfig GetAdminConfig()
        {
            return _configuration.GetSection(nameof(AdminClientConfig)).Get<AdminClientConfig>();
        }

        public SchemaRegistryConfig GetSchemaRegistryConfig()
        {
            return _configuration.GetSection(nameof(SchemaRegistryConfig)).Get<SchemaRegistryConfig>();
        }

    }
}
