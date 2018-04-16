using System;
using EventDemo.Abstraction;

namespace EventDemo.CarDemo {
    public class DriverHandler : IEventHandler<CarNotificationEventData> {
        public void EventHandle (CarNotificationEventData carNotificationEventData) {
            Console.WriteLine ("Driver Hanlder---------");
            Console.WriteLine (carNotificationEventData.Driver + "\n" + carNotificationEventData.Passenger +
                "\n" + carNotificationEventData.EventDate);
        }
    }
}