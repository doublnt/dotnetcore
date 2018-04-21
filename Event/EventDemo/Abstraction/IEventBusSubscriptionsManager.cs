using EventDemo.CarDemo;

namespace EventDemo.Abstraction {
    public interface IEventBusSubscriptionsManager {
        bool IsEmpty { get; }

        event CarNotificationDelegate OnEventRemoved;

        void AddSubscription<T, TH> () where T : CarNotificationEventData where TH : IEventHandler<T>;

        void RemoveSubscription<T, TH> (T eventBusData) where T : CarNotificationEventData where TH : IEventHandler<T>;

        bool HasSubscriptionsForEvent<T> () where T : CarNotificationEventData;

        bool HasSubscriptionsForEvent (string eventName);
    }
}