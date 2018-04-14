using System;

namespace EventDemo.CarDemo {

    public delegate void CarHandler ();

    public class MyCar {
        //定义一个 上车 委托方法的事件
        public event CarHandler CarNumberNotification;

        public void RunCar () {
            Console.WriteLine ($"好的，准备上车了！");
            if (CarNumberNotification != null) {
                CarNumberNotification ();
            }
        }
    }
}