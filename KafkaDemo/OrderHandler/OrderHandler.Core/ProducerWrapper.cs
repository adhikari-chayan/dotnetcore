using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace OrderHandler.Core
{
    public class ProducerWrapper
    {
        private string _topicName;
        private ProducerConfig _config;
        

        public ProducerWrapper(ProducerConfig config, string topicName)
        {
            _topicName = topicName;
            _config = config;
        }

        public async Task WriteMessage(string key,string message)
        {
            using var producer = new ProducerBuilder<string, string>(_config).Build();
            var result = await producer.ProduceAsync(this._topicName, new Message<string, string>()
            {
                Key = key,
                Value = message
            });
            Console.WriteLine($"\nMsg: Event is queued at offset {result.Offset.Value} in the Topic {result.Topic}:{result.Partition.Value}\n\n");
            return;
        } 

    }
}
