using System;

namespace EventDemo.CarDemo {
    public class Driver {
        public string Name { get; set; }

        public void DriveCar () {
            Console.WriteLine ($"I am driver:{Name}");
        }
    }
}