using System;

namespace EqualSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string value1 = "equaltest";
            string value2 = string.Copy(value1);

            Console.WriteLine("Reference Compare: {0}", ReferenceEquals(value1, value2));

            Console.WriteLine("Equal Compare: {0}", value1.Equals(value2));
        }
    }
}
