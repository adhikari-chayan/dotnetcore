using Notifications;

namespace NotificationBroker.Hubs;

public interface IChatHub
{
    Task ReceivePost(PostAddedNotification notification);

    Task OnSomeoneConnected();

    Task OnSomeoneDisconnected();
}