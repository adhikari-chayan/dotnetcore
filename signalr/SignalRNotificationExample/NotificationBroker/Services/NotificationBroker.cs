using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using NotificationBroker.Hubs;
using NotificationBroker.Infrastructure;
using Notifications;

namespace NotificationBroker.Services;

public class NotificationBroker : BackgroundService
{
    private readonly IHubContext<ChatHub, IChatHub> _chatHubContext;

    private readonly ILogger _logger;

    private readonly JsonSerializerOptions jsonOptions = new()
                                                         {
                                                             PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                         };

    public NotificationBroker(
        IHubContext<ChatHub, IChatHub> chatHubContext,
        ILoggerFactory loggerFactory)
    {
        _chatHubContext = chatHubContext;
        _logger = loggerFactory.CreateLogger(GetType());
    }

    private readonly string ServiceName = nameof(NotificationBroker);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"{ServiceName} is starting.");

        stoppingToken.Register(() =>
                                   _logger.LogInformation($"{ServiceName} background task is stopping."));

        // Subscribe to channels
        await RedisConnection.Connection.GetSubscriber().SubscribeAsync("PostCreated",
                                                                        async (channel, message) =>
                                                                        {
                                                                            _logger.LogInformation($"PostAdded -> {message}");

                                                                            var notification = JsonSerializer
                                                                                .Deserialize<PostAddedNotification>(message, jsonOptions);

                                                                            await _chatHubContext.Clients
                                                                                                 .Group(ChatHubConstants.GroupName)
                                                                                                 .ReceivePost(notification);
                                                                        });

        await Task.Delay(Timeout.Infinite, stoppingToken);

        _logger.LogDebug($"{ServiceName} is stopping.");
    }
}