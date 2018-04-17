using System;

namespace EventDemo.CarDemo {
    public class Passenger {

        public Passenger (CarManager carManager) {
            carManager.CarNotification += new PassengerHandler ().EventHandle;
        }
        public string Name { get; set; }
    }
}