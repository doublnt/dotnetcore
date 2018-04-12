using System;

namespace EventDemo {
    public class MyCar {
        //定义一个 上车 的委托
        public delegate void BeginOnCarHandler ();

        //定义一个 上车 委托方法的事件
        public event BeginOnCarHandler CarNotification;

        public string Name { get; set; }

        public void RunCar () {
            CarNotification ();
            Console.WriteLine ("好的，都上车了司机" + Name + "，开车了");
        }
    }
}