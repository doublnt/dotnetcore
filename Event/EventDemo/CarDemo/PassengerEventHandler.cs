using EventDemo.Abstraction;

namespace EventDemo.CarDemo {
    public class PassengerEventHandler : IEventHandler<PassengerEventData> {
        public void EventHandle (PassengerEventData eventData) {
        }
    }
}