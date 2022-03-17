using InMemoryMessageBus.Interfaces;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace InMemoryMessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly object @lock = new object();
        private readonly ISubject<IMessage> messagesStream;
        private IObservable<IMessage> messageStreamListener;
        private IMessagePublisher busMessagePublisher;

        public MessageBus()
        {
            messagesStream = new Subject<IMessage>();

            messageStreamListener = messagesStream
                                   .ObserveOn(TaskPoolScheduler.Default)
                                   .SubscribeOn(TaskPoolScheduler.Default)
                                   .Do(LogIncomeMessage)
                                   .Publish()
                                   .RefCount()
                                   .Where(x => x != null);
        }

        public void DisposeMessageBus()
        {
            messagesStream.OnCompleted();
        }

        public IMessagePublisher GetPublisher()
        {            
            if (busMessagePublisher == null)
            {
                lock (@lock)
                {
                    if (busMessagePublisher == null)
                    {
                        busMessagePublisher = new MessagePublisher(messagesStream);
                    }
                }
            }

            return busMessagePublisher;
        }

        public IDisposable RegisterListener(IMessageListener listener)
        {         
            return messageStreamListener.Where(x => listener.Filters.Contains(x.MessageType))
                                        .ObserveOn(TaskPoolScheduler.Default)
                                        .SubscribeOn(TaskPoolScheduler.Default)
                                        .Subscribe(listener.OnReceived);
        }

        private void LogIncomeMessage(IMessage incomingMessage)
        {
            Console.WriteLine($"Received new message with id: {incomingMessage?.MessageId ?? "null"} at {DateTime.UtcNow} UTC");
        }
       
    }
}
