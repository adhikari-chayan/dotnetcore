namespace ObservableDataStream.Demo
{
    internal class EventProvider
    {       
        public ObservableDataStream<Event> EventStream { get; set; }
        private readonly Dictionary<Guid, Event> _events = new();
        private Random _rnd = new Random();
        public EventProvider()
        {
            Initialize();
        }

        private void Initialize()
        {
            EventStream = new ObservableDataStream<Event>();

            for (var i = 0; i < 5; i++)
            {
                var id = Guid.NewGuid();
                _events.Add(id, new Event
                {
                    Id = id,
                    Title = $"Test Event - {i+1}",
                    StartDateTime = DateTime.Now.AddDays(_rnd.Next(1,10)),
                    EndDateTime = DateTime.Now.AddDays(_rnd.Next(11,21))                   
                });
            }
        }

        public List<Event> GetAllEvents()
        {
            return _events.Values.ToList();
        }

        public void UpdatedEvent()
        {
            var events = GetAllEvents();
            var @event = events[_rnd.Next(0,4)];            
            @event.Title = "Change Title";
            _events[@event.Id] = @event;
            EventStream.NewData(@event);
            
        }

        public void AddNewEvent() 
        {
            var @event = new Event
            {
                Id = Guid.NewGuid(),
                Title = $"Test Event - {_rnd.Next(6,50)}",
                StartDateTime = DateTime.Now.AddDays(_rnd.Next(1, 10)),
                EndDateTime = DateTime.Now.AddDays(_rnd.Next(11, 21))
            };

            _events.Add(@event.Id, @event);
            EventStream.NewData(@event);
        }
    }
}
