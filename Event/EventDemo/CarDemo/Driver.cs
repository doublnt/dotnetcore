using System;

namespace EventDemo.CarDemo {
    public class Driver {

        public Driver (CarManager carManager) {
            carManager.CarNotification += DriverHandle;
        }

        public string Name { get; set; }

        public void DriverHandle (CarNotificationEventData carNotificationEventData) {
            Console.WriteLine ("Driver Hanlder---------");
            Console.WriteLine (carNotificationEventData.Driver + "\n" + carNotificationEventData.Passenger +
                "\n" + carNotificationEventData.NotifiDate);
        }

        public void UnRegister (CarManager carManager) {
            carManager.CarNotification -= DriverHandle;
        }
    }
}