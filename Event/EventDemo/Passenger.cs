namespace EventDemo {
    public class Passenger {

        public string Name { get; set; }

        public void BeginToCar (MyCar car) {
            car.Count++;
            System.Console.WriteLine ($"我上车了，我是：{Name}，我坐的车是{car.Name}");
        }
    }
}