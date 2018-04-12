using System;

namespace EventDemo.EventBus {
    public class EventData : IEventData {
        public DateTime EventDate { get; set; }
        public object EventSource { get; set; }

        public EventData () {
            EventDate = DateTime.Now;
        }
    }
}