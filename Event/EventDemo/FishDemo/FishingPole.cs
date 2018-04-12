using System;
using System.Reflection;
using EventDemo.Abstraction;
using EventDemo.EventBus;

namespace EventDemo.FishDemo {
    public class FishingPole {
        public delegate void FishingHanlder (FishingEventData fishingEventData);

        public event FishingHanlder FishingEvent;

        public FishingPole () {
            Assembly assembly = Assembly.GetExecutingAssembly ();
            foreach (var type in assembly.GetTypes ()) {
                if (typeof (IEventHandler).IsAssignableFrom (type)) {
                    Type handlerInterface = type.GetInterface ("IEventHandler`1");
                    Type eventDataType = handlerInterface.GetGenericArguments () [0];

                    if (eventDataType.Equals (typeof (FishingEventData))) {
                        var hanlder = Activator.CreateInstance (type) as IEventHandler<FishingEventData>;
                        FishingEvent += hanlder.EventHandle;
                    }
                }
            }
        }

        public void ThrowPole (FishingMan man) {
            Console.WriteLine ("Begin To Throw!");

            if (new Random ().Next () % 2 == 1) {
                var type = (FishType) new Random ().Next (0, 5);

                Console.WriteLine ("Fish got it");
                if (FishingEvent != null) {
                    var fishingEventData = new FishingEventData { FishType = type, FishingMan = man };
                    // FishingEvent (new FishingEventData { FishType = type, FishingMan = man });
                    EventBusManager.Default.Trigger<FishingEventData> (fishingEventData);
                }
            } else {
                Console.WriteLine ("Got nothing this time!");
            }
        }
    }
}