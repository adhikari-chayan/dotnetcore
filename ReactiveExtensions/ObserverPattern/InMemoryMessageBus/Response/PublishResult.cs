namespace InMemoryMessageBus.Response
{
    public abstract class PublishResult
    {
        public abstract PublishState State { get; }
    }
}