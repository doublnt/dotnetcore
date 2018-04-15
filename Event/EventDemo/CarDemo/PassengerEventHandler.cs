using EventDemo.Abstraction;

namespace EventDemo.CarDemo {
    public class PassengerEventHandler : IEventHandler<CarNotificationEventData> {
        public void EventHandle (CarNotificationEventData eventData) { }
    }
}