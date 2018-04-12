using System;

namespace EventDemo {
    public class MyCar {
        //定义一个 上车 的委托
        public delegate void CarHandler (MyCar car);

        //定义一个 上车 委托方法的事件
        public event CarHandler CarNumberNotification;

        public string Name { get; set; }

        public int Count { get; set; }

        public void RunCar () {
            Console.WriteLine ($"好的，准备上车了，车名为:{Name}，车上人数:{Count}");
            if (CarNumberNotification != null) {
                CarNumberNotification (this);
            }
            Console.WriteLine ($"The people now is:{Count}");
        }
    }
}