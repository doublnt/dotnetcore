using System.Threading.Tasks;
using EventBusDemo.Events;

namespace EventBusDemo.EventBus.Abstractions {
        public interface IIntegrationEventHandler { }
        public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler 
        where TIntegrationEvent : IntegrationEvent {
                Task Handle (TIntegrationEvent @event); 
        }
}