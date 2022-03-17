using ObservableDataStream.Demo;
using System.Collections.Concurrent;


var tokenSource = new CancellationTokenSource();
var token = tokenSource.Token;
var eventProvider = new EventProvider();


//change to concurrentdictionary - http://dotnetpattern.com/csharp-concurrentdictionary
var eventList = new ConcurrentDictionary<Guid,Event>();//Get all from EventProvider store while initializing
var eventsInStore = eventProvider.GetAllEvents();
foreach (var @event in eventsInStore)
{
    eventList.TryAdd(@event.Id, @event);
}

//UiWriterTask->writes event list items every 5s in console.
var uiWriterTask = Task.Run(async () =>
{
    while (!token.IsCancellationRequested)
    {
        Console.Clear();

        if (!eventList.Any())
            Console.WriteLine("No events in list");
        foreach (var @event in eventList.Values)
        {
            Console.WriteLine($"Title: {@event.Title} | Start: {@event.StartDateTime} | End: {@event.EndDateTime}");
        }

        await Task.Delay(5000);
    }
});

//AddOrUpdateTask-->Adds or updates new events every 2s in EventProvider Store which in turn puts data in stream(run a loop. For odd index add, for even index update).  
var addOrUpdateTask = Task.Run(async () => { 
    for(int i = 0; i < 20; i++)
    {
        if (i % 2 == 0)
            eventProvider.AddNewEvent();
        else
            eventProvider.UpdatedEvent();
        await Task.Delay(2000);
    }

});

//ListenerTask -->Subscribes to the EventsStream and updates the eventList if there are new additions or updates to EventProvider Store.
var listenerTask = Task.Run(() => {
    eventProvider.EventStream.Subscribe(OnEventMessage);

});

void OnEventMessage(Event @event)
{
   eventList.AddOrUpdate(@event.Id, @event, (key, oldValue) => @event);
}

tokenSource.CancelAfter(TimeSpan.FromSeconds(100));
await Task.WhenAll(uiWriterTask,addOrUpdateTask,listenerTask);