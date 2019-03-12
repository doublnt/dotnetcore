using System;

namespace CSharpFundamental
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Public get and set method
            PrivateClass pClass = new PrivateClass();
            pClass.Name = "Robert";
            Console.WriteLine(pClass.Name);

            pClass.Version = "1.0";
            Console.WriteLine(pClass.Version);

            pClass = new PrivateClass("Robert", "2.0", "fakeHashcode");

            Console.WriteLine(pClass.Name + "|" + pClass.Version + "|" + pClass.HashCode);

            new AnonymousType().CreateAnonymousAndExecute();

            TestConstrcutor tc = new TestConstrcutor("222");
        }
    }

    class TestConstrcutor : ConstructorClass
    {
        public TestConstrcutor() : base() { }

        public TestConstrcutor(string param1) : base(param1) { }
    }
}
