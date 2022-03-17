using System;

namespace InMemoryMessageBus.Response
{
    public class FailedPublishResult : PublishResult
    {
        public FailedPublishResult(string message, Exception exception)
        {
            Message = message;
            Exception = exception;
        }

        public override PublishState State => PublishState.Failed;

        public string Message { get; }

        public Exception Exception { get; }
    }
}