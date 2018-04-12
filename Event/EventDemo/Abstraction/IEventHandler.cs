using EventDemo.EventBus;

namespace EventDemo.Abstraction {
    public interface IEventHandler {

    }

    public interface IEventHandler<TEventData> : IEventHandler where TEventData : IEventData {
        void EventHandle (TEventData eventData);
    }
}