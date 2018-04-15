using System;
using System.Threading;

namespace EventDemo.CarDemo {

    public delegate void CarNotificationEventHandler (CarNotificationEventData eventData);

    public class CarManager {

        //定义一个 上车通知 事件 成员类型为 CarNoticationEventHandler
        public event CarNotificationEventHandler CarNotification;

        public void OnCarToRun (CarNotificationEventData carNotificationEventData) {

            //将委托字段的引用复制到一个临时变量中
            CarNotificationEventHandler temp = Volatile.Read (ref CarNotification);

            if (temp != null) {
                temp (carNotificationEventData);
            }
        }

        public void RunCar (Driver driver, Passenger passenger) {
            CarNotificationEventData carNotificationEventData = new CarNotificationEventData (driver.Name, passenger.Name);
            OnCarToRun (carNotificationEventData);
        }
    }
}