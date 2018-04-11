using EventBusDemo.Events;

namespace EventBusDemo.EventBus.Abstractions {
        public interface IEventBus {
            void Publish (IntegrationEvent @event); 
        void Subscribe<T, TH> () where T:IntegrationEvent where TH:IIntegrationEventHandler<T>; 
        void SubscibeDynamic<TH> (string eventName) where TH:IDynamicIntegrationEventHandler; 
        void UnSubscribe<T, TH> () where T:IntegrationEvent where TH:IIntegrationEventHandler<T>; 
        void UnSubscribeDynamic<TH> (string eventName) where TH:IDynamicIntegrationEventHandler; 
    }
}