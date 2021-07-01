using MediatR;
using MediatRNotificationDemo.Messages;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRNotificationDemo.Handlers
{
    public class Notifier1 : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<Notifier1> _logger;

        public Notifier1(ILogger<Notifier1> logger)
        {
            _logger = logger;
        }
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Debugging from Notifier 1. Message  : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }
}
