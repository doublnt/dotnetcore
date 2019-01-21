using System;

namespace AbstractDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird a = new ExplictBird("DiDi");
            
            a.PrintBird();
        }
    }

    abstract class Bird
    {
        private string BirdName;

        public abstract void PrintBird();

        public void PrintBirdSon()
        {
            Console.WriteLine("Hello, World!" + BirdName);
        }
        public string GetName(){
            return BirdName;
        }
        
        public void SetName(string name){
            BirdName = name;
        }
    }

    class ExplictBird : Bird
    {
        public ExplictBird(string name){
            base.SetName(name);
        }
        public override void PrintBird()
        {
            Console.WriteLine("Hello, Bird" + base.GetName());
        }
    }
}
