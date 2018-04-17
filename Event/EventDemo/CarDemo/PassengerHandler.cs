using System;
using EventDemo.Abstraction;

namespace EventDemo.CarDemo {
    public class PassengerHandler : IEventHandler<CarNotificationEventData> {
        public void EventHandle (CarNotificationEventData carNotificationEventData) {
            Console.WriteLine ("Passenger Handler----------");
            Console.WriteLine (carNotificationEventData.Driver + "is the driver \n the passenger is " +
                carNotificationEventData.Passenger + carNotificationEventData.EventDate);
        }
    }
}