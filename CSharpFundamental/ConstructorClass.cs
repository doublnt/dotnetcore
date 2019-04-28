using System;

namespace CSharpFundamental
{
    public class ConstructorClass
    {
        public ConstructorClass()
        {
            System.Console.WriteLine("None params constructor!");
        }

        public ConstructorClass(string param1)
        {
            System.Console.WriteLine("One Params: {0}", param1);
        }

        internal struct Point
        {
            public Int32 x, y;

            //ERROR In Compile
            // public Point()
            // {
            //     x = 5;
            //     y = 5;
            // }
        }
    }
}
