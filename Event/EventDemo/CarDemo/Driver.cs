using System;

namespace EventDemo.CarDemo {
    public class Driver {

        public Driver (CarManager carManager) {
            carManager.CarNotification += new DriverHandler ().EventHandle;
        }

        public string Name { get; set; }
    }
}