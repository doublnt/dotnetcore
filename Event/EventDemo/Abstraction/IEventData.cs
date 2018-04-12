using System;

namespace EventDemo.EventBus {
    public interface IEventData {
        DateTime EventDate { get; set; }

        object EventSource { get; set; }
    }
}