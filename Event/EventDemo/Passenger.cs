namespace EventDemo {
    public class Passenger {

        public string Name { get; set; }

        public void BeginToCar () {
            System.Console.WriteLine ("我上车了:" + Name);
        }
    }
}