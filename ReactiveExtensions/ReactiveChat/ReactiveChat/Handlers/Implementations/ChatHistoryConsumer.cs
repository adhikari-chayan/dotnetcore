using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using ReactiveChat.Models;

namespace ReactiveChat.Handlers.Implementations
{
    public class ChatHistoryConsumer : BackgroundService
    {
        private readonly IChatEventHandler _chatEventHandler;

        public ChatHistoryConsumer(IChatEventHandler chatEventHandler)
        {
            _chatEventHandler = chatEventHandler;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _chatEventHandler.Subscribe(subscriberName: typeof(ChatHistoryConsumer).Name,
                                    action: async (e) =>
                                    {
                                        if (e is ChatMessageReceivedEvent)
                                        {
                                            await PersistChatMessagesToDBAsync((ChatMessageReceivedEvent)e);
                                        }
                                    });

            return Task.CompletedTask;
        }

        private async Task PersistChatMessagesToDBAsync(ChatMessageReceivedEvent e)
        {
            await System.Console.Out.WriteLineAsync($"Chat message received and persisted: {e.Message}");
        }
    }
}