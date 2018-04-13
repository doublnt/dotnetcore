using EventDemo.EventBus;

namespace EventDemo.FishDemo {
    public class FishingEventData : EventData {
        public FishType FishType { get; set; }

        public FishingMan FishingMan { get; set; }
    }
}