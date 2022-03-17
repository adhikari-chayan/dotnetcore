using InMemoryMessageBus.Interfaces;
using InMemoryMessageBus.Response;

namespace InMemoryMessageBus
{
    public static class MessageHelpers
    {
        public static string GenerateUniqueMessageId(string prefix = null)
           => NotNullStringJoin(prefix,
                                DateTime.UtcNow.ToFileTimeUtc(),
                                Guid.NewGuid().ToString("D").Split('-').First(),
                                Environment.MachineName.ToUpper(),
                                Thread.CurrentThread.ManagedThreadId);

        public static string NotNullStringJoin(params object[] @params) => string.Join("|", @params.Where(x => x != null));

        public static T ValidateIncomingMessage<T>(IMessage message)
           where T : IMessage
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (message is T typedMessage)
            {
                return typedMessage;
            }

            throw new NotSupportedException($"Received unsupported message of type: {message.GetType()}");
        }

        public static void ProcessFailedPublish(PublishResult result)
        {
            if (result.State == PublishState.Failed)
            {
                var failedResult = result as FailedPublishResult;
                throw new Exception($"Failed to publish message. Details: {failedResult?.Message}", failedResult?.Exception);
            }
        }
    }
}
