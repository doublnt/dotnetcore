using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.LazyInitialization
{
    internal class LazyInitializationSample
    {
        public void LazyDemo()
        {
            Lazy<Person> lazyPerson = new Lazy<Person>();

            if (lazyPerson.IsValueCreated)
            {
                Console.WriteLine("Is Created.");
            }

            Console.WriteLine(lazyPerson.Value.Name);

            Console.WriteLine($"IS Created: {lazyPerson.IsValueCreated}");
        }
    }

    internal class Person
    {
        public Person()
        {
            Name = "Robert";
            Age = 24;
        }

        public string Name { get; set; }
        public uint Age { get; set; }
    }
}
