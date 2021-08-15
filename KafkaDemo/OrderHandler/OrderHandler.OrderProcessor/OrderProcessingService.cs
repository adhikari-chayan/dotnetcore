using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderHandler.Core;
using OrderHandler.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderHandler.OrderProcessor
{
    public class OrderProcessingService : BackgroundService
    {
        private readonly ConsumerConfig _consumerConfig;
        private readonly ProducerConfig _producerConfig;
        private readonly AdminClientConfig _adminClientConfig;

        public OrderProcessingService(ConsumerConfig consumerConfig, ProducerConfig producerConfig,AdminClientConfig adminClientConfig)
        {
            _consumerConfig = consumerConfig;
            _producerConfig = producerConfig;
            _adminClientConfig = adminClientConfig;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await KafkaHelper.CreateTopicAsync(_adminClientConfig, ApplicationConstants.ReadyToShipTopicName, 1);
            await base.StartAsync(cancellationToken);

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("OrderProcessing Service Started");
            while (!stoppingToken.IsCancellationRequested)
            {
                var consumerWrapper = new ConsumerWrapper(_consumerConfig, ApplicationConstants.OrderRequestsTopicName);
                string orderRequest = consumerWrapper.ReadMessage();

                //Deserilaize 
                OrderRequest order = JsonConvert.DeserializeObject<OrderRequest>(orderRequest);

                //TODO:: Process Order
                Console.WriteLine($"Info: OrderHandler => Processing the order for {order.ProductName}");
                order.Status = OrderStatus.COMPLETED;

                //Write to ReadyToShip Queue

                var producerWrapper = new ProducerWrapper(_producerConfig, ApplicationConstants.ReadyToShipTopicName);
                await producerWrapper.WriteMessage(order.Id.ToString(),JsonConvert.SerializeObject(order));

            }
        }
    }
}
