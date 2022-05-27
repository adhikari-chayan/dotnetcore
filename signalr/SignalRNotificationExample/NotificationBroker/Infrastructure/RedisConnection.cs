using StackExchange.Redis;

namespace NotificationBroker.Infrastructure;

public static class RedisConnection
{
    public static ConnectionMultiplexer Connection { get; } = ConnectionMultiplexer.Connect("localhost");
}