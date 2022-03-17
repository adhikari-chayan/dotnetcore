namespace InMemoryMessageBus.Response
{
    public class SuccessPublishResult : PublishResult
    {
        public static PublishResult Instance = new SuccessPublishResult();

        public override PublishState State => PublishState.Success;
    }
}