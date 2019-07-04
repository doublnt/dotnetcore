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
//            public Int32 x, y;

            //ERROR In Compile
            // public Point()
            // {
            //     x = 5;
            //     y = 5;
            // }
        }
    }

    internal class TestConstrcutor : ConstructorClass
    {
        public TestConstrcutor()
        {
        }

        public TestConstrcutor(int a)
        {

        }

        public TestConstrcutor(string str, int a) : this(a)
        {
            System.GC.Collect(0);
        }

        public TestConstrcutor(string param1) : base(param1)
        {
        }

        public void SetNamespaceParams(int x, int y)
        {
            Console.WriteLine("X: {0} Y: {1}", x, y);
        }

        protected void Finalize()
        {
            Finalize();
        }
    }
}
