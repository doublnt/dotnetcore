using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace AbstractDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bird a = new ExplictBird("DiDi");

            // a.PrintBird();

            string outputTemplate = "{age} {name} {test} {22}{NewLine}";
            var logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .CreateLogger();

            object[] value = { "1008", "robert", "test", "invalue" };

            var list = new List<string>{
                "1008",
                "robert",
                "test",
                "invalue"
            };

            var testValue = list.Cast<object>().ToArray();

            logger.Information(outputTemplate, value);
            logger.Information(outputTemplate, testValue);
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
        public string GetName()
        {
            return BirdName;
        }

        public void SetName(string name)
        {
            BirdName = name;
        }
    }

    class ExplictBird : Bird
    {
        public ExplictBird(string name)
        {
            base.SetName(name);
        }
        public override void PrintBird()
        {
            Console.WriteLine("Hello, Bird" + base.GetName());
        }
    }
}