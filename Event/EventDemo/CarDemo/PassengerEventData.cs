using EventDemo.EventBus;

namespace EventDemo.CarDemo {
    public class PassengerEventData : EventData {
        public string Name { get; set; }
        public Driver Driver { get; set; }
    }
}