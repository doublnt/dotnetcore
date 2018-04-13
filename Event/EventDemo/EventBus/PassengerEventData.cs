using EventDemo.CarDemo;

namespace EventDemo.EventBus {
    public class PassengerEventData : EventData {
        public string Name { get; set; }

        public MyCar MyCar { get; set; }
    }
}