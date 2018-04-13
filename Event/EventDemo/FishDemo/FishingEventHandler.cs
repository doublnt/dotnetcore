using EventDemo.Abstraction;

namespace EventDemo.FishDemo {
    public class FishingEventHandler : IEventHandler<FishingEventData> {
        public void EventHandle (FishingEventData eventData) {
            eventData.FishingMan.Count++;

            System.Console.WriteLine ($"{eventData.FishingMan.Name}: Got a Fish, Fish type is {eventData.FishType}, Fish Count is {eventData.FishingMan.Count}");
        }
    }
}