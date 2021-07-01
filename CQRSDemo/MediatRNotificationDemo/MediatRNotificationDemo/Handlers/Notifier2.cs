using MediatR;
using MediatRNotificationDemo.Messages;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRNotificationDemo.Handlers
{
    public class Notifier2 : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<Notifier2> _logger;

        public Notifier2(ILogger<Notifier2> logger)
        {
            _logger = logger;
        }
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Debugging from Notifier 2. Message  : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }
}
