using EventDemo.FishDemo;

namespace EventDemo.EventBus {
    public class FishingEventData : EventData {
        public FishType FishType { get; set; }

        public FishingMan FishingMan { get; set; }
    }
}