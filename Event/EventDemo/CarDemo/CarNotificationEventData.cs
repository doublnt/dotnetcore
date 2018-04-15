using System;
using EventDemo.EventBus;

namespace EventDemo.CarDemo {
    public class CarNotificationEventData : EventData {
        private string _driverName;
        private string _passengerName;

        public CarNotificationEventData (string driver, string passenger) {
            _driverName = driver;
            _passengerName = passenger;
        }

        public string Driver { get { return _driverName; } }

        public string Passenger { get { return _passengerName; } }

        public DateTime NotifiDate { get { return DateTime.Now; } }
    }
}