using System;

namespace EventDemo {
    public class MyCar {
        //定义一个 上车 的委托
        public delegate void BeginOnCarHandler ();

        //定义一个 上车 委托方法的事件
        public event BeginOnCarHandler RaiseCar;

        public string Name { get; set; }

        public void RunCar () {
            Console.WriteLine (Name + "开车了");
            RaiseCar ();
        }
    }
}