using EventDemo.Abstraction;
using EventDemo.EventBus;

namespace EventDemo.FishDemo {
    public class FishingMan {
        public string Name { get; set; }

        public int Count { get; set; }

        public FishingPole FishingPole { get; set; }

        public void Fishing () {
            FishingPole.ThrowPole (this);
        }

        public void Update (FishingEventData fishingEventData) {
            Count++;
            System.Console.WriteLine ($"{Name}: Got a Fish, Fish type is {fishingEventData.FishType}, Fish Count is {Count}");
        }
    }
}