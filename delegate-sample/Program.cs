using System;

namespace delegate_sample
{
    class Program
    {
        delegate void PrintMessage(string content);

        static void Main(string[] args)
        {
            PrintMessage dogPrint, catPrint;

            Animal dog = new Animal();
            Animal cat = new Animal();

            dogPrint = new PrintMessage(dog.SayHi);
            catPrint = new PrintMessage(cat.SayHi);

            dogPrint("wawawawa");
            catPrint("miaomiaomiaomiao!!!!");

            Console.WriteLine("Hello World!");

            EventHandler eventHandler = new EventHandler(new Animal().HandlerEventDemo);

            eventHandler(null, EventArgs.Empty);

            eventHandler = new Animal().HandlerEventDemo;
            eventHandler(null, EventArgs.Empty);

            eventHandler = delegate(object sender, EventArgs e)
            {
                Console.WriteLine("Handler anonymously");
            };

            eventHandler = delegate
            {
                Console.WriteLine("Handler anonymously!");
            };
        }
    }

    public class Animal
    {
        public void SayHi(string content)
        {
            Console.WriteLine(content);
        }

        public void HandlerEventDemo(object sender, EventArgs e)
        {
            Console.WriteLine("Test!!!!!");
        }
    }
}
