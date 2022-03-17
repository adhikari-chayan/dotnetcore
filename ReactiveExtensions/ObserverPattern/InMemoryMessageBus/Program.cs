using InMemoryMessageBus;
using InMemoryMessageBus.Entities;
using InMemoryMessageBus.Interfaces;
using InMemoryMessageBus.Messages;

var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;
IList<IDisposable> messageListenerSubscriptions = new List<IDisposable>();
IEnumerable<IMessageListener> messageListeners = GetMessageListeners();
var _rnd = new Random();

//instantiate messeagebus. This should be a singleton in asp.net core apis
IMessageBus messageBus = new MessageBus();

//RegisterListeners that implement IMessageListeners
RegisterListeners();

//product publish task--> every 1s
var productPublishTask = Task.Run(async () => {
    var index = 0;
    while (!token.IsCancellationRequested)
    {
        var product = new Product { Id = index + 1, Name = $"TestProduct{index + 1}", Price = _rnd.Next(1, 500) };
        var messageId = MessageHelpers.GenerateUniqueMessageId();
        var productMessage = new ProductMessage(messageId, product);
        var publisher = messageBus.GetPublisher();
        publisher.Publish(productMessage);
        index++;
        await Task.Delay(1000);
    }
});

//order publish task --> every 2s
var orderPublishTask = Task.Run(async () => {
    var index = 0;
    while (!token.IsCancellationRequested)
    {
        var order = new Order { Id = index + 1};
        var messageId = MessageHelpers.GenerateUniqueMessageId();
        var orderMessage = new OrderMessage(messageId, order);
        var publisher = messageBus.GetPublisher();
        publisher.Publish(orderMessage);
        index++;
        await Task.Delay(2000);
    }
});

//payment publish task --> every 5s
var paymentPublishTask = Task.Run(async () => {
    var index = 0;
    while (!token.IsCancellationRequested)
    {
        var payment = new Payment { Id = index + 1, OrderId = _rnd.Next(100,150), Amount = _rnd.Next(1,10) };
        var messageId = MessageHelpers.GenerateUniqueMessageId();
        var paymentMessage = new PaymentMessage(messageId, payment);
        var publisher = messageBus.GetPublisher();
        publisher.Publish(paymentMessage);
        index++;
        await Task.Delay(5000);
    }
});


void RegisterListeners()
{
    foreach (var listener in messageListeners ?? Enumerable.Empty<IMessageListener>())
    {
        messageListenerSubscriptions.Add(messageBus.RegisterListener(listener));
    }
}

IEnumerable<IMessageListener> GetMessageListeners()
{
    var type = typeof(IMessageListener);

    return type.Assembly.ExportedTypes.
    Where(x => typeof(IMessageListener).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
   .Select(Activator.CreateInstance).Cast<IMessageListener>();

   
}

tokenSource.CancelAfter(TimeSpan.FromSeconds(10));
await Task.WhenAll(productPublishTask, orderPublishTask, paymentPublishTask);

messageBus.DisposeMessageBus();