using System;
using System.Collections.Generic;
using EventBusDemo.Events;

namespace EventBusDemo.EventBus.Abstractions {
    public interface IEventBusSubscriptionsManager {
        bool IsEmpty { get; }
        event EventHandler<string> OnEventRemoved;

        void AddDynamicSubscription<TH> (string eventName) where TH : IDynamicIntegrationEventHandler;
        void AddSubscription<T, TH> () where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        void RemoveDynamicSubscription<TH> (string eventName) where TH : IDynamicIntegrationEventHandler;
        void RemoveSubscription<T, TH> () where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        bool HasSubscriptionsForEvent<T> () where T : IntegrationEvent;
        bool HasSubscriptionsForEvent (string eventName);

        Type GetEventTypeByName (string eventName);
        void Clear ();
        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T> () where T : IntegrationEvent;
        IEnumerable<SubscriptionInfo> GetHandlersForEvent (string eventName);
        string GetEventKey<T> ();

    }
}