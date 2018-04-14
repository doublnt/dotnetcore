namespace EventDemo.CarDemo {
    public class Passenger {

        public string Name { get; set; }

        public void BoardCar () {
            System.Console.WriteLine ($"我上车了，我是：{Name}");
        }
    }
}