using System;
using System.Threading;
using EventDemo.EventBus;

namespace EventDemo.CarDemo {

    public delegate void CarNotificationEventHandler (CarNotificationEventData eventData);

    public class CarManager {

        //定义一个 上车通知 事件 成员类型为 CarNoticationEventHandler
        public event CarNotificationEventHandler CarNotification;

        public EventBusManager eventBusManager => EventBusManager.Default;

        public CarManager () {
            eventBusManager.Register<CarNotificationEventData> (typeof (DriverHandler));
            eventBusManager.Register<CarNotificationEventData> (typeof (PassengerHandler));
        }

        public void OnCarToRun (Driver driver, Passenger passenger) {

            //将委托字段的引用复制到一个临时变量中
            CarNotificationEventHandler temp = Volatile.Read (ref CarNotification);
            CarNotificationEventData carNotificationEventData = new CarNotificationEventData (driver.Name, passenger.Name);

            if (temp != null) {
                eventBusManager.Trigger<CarNotificationEventData> (carNotificationEventData);
                // temp (carNotificationEventData);
            }
        }
    }
}