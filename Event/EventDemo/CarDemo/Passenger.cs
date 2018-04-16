using System;

namespace EventDemo.CarDemo {
    public class Passenger {

        public Passenger (CarManager carManager) {
            carManager.CarNotification += PassengerHandle;
        }
        public string Name { get; set; }

        public void PassengerHandle (CarNotificationEventData carNotificationEventData) {
            Console.WriteLine ("Passenger Handler----------");
            Console.WriteLine (carNotificationEventData.Driver + "is the driver \n the passenger is " +
                carNotificationEventData.Passenger + carNotificationEventData.EventDate);
        }

        public void UnRegister (CarManager carManager) {
            carManager.CarNotification -= PassengerHandle;
        }

    }
}