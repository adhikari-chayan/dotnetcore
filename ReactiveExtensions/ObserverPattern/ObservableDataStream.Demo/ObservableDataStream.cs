using System.Collections.Concurrent;

namespace ObservableDataStream.Demo
{
    public class ObservableDataStream<T> : IObservable<T>
    {
        private readonly ConcurrentDictionary<Guid, Subscription> subscriptions;

        public ObservableDataStream()
        {            
            subscriptions = new ConcurrentDictionary<Guid, Subscription>();
        }

        public void NewData(T data)
        {
            try
            {
                foreach (var subscription in subscriptions)
                {
                    subscription.Value.Observer.OnNext(data);
                }
            }
            catch (Exception err)
            {
                
            }
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            var subscription = new Subscription(Unsubscribe, observer);
            subscriptions.TryAdd(subscription.SubscriptionId, subscription);

            return subscription;
        }       

        private void Unsubscribe(Guid subscriptionId)
        {
            Subscription _;
            subscriptions.TryRemove(subscriptionId, out _);
        }

        private class Subscription : IDisposable
        {
            private readonly Action<Guid> unsubscribe;

            internal Subscription(Action<Guid> unsubscribe, IObserver<T> observer)
            {
                SubscriptionId = Guid.NewGuid();
                this.unsubscribe = unsubscribe;
                Observer = observer;
            }

            public void Dispose()
            {
                unsubscribe(SubscriptionId);
            }

            internal Guid SubscriptionId { get; }

            internal IObserver<T> Observer { get; }
        }
    }
}
