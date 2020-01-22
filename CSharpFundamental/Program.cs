using System;

namespace CSharpFundamental
{
    internal class Program
    {
        private static Func<string> TestFunc;

        public static void Main(string[] args)
        {
            InvokeDelegate();
            Console.WriteLine(TestFunc());
        }

        private static void InvokeDelegate()
        {
            TestFunc += GetResult;
            // Equal to below
            
            
        }

        public static string GetResult()
        {
            return "TESTTEST";
        }
    }
}
