using Confluent.Kafka;

namespace OrderHandler.Core
{
    public class ConsumerWrapper
    {
        private string _topicName;
        private ConsumerConfig _consumerConfig;
        private IConsumer<string, string> _consumer;

        public ConsumerWrapper(ConsumerConfig config, string topicName)
        {
            _topicName = topicName;
            _consumerConfig = config;
            _consumer = new ConsumerBuilder<string, string>(_consumerConfig).Build();
            _consumer.Subscribe(topicName);
        }

        public string ReadMessage()
        {
            var result = _consumer.Consume();

            _consumer.Commit(result);
            _consumer.StoreOffset(result);

            return result.Message.Value;

        }
    }

}

