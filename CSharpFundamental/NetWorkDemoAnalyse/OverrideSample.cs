using System;

namespace CSharpFundamental.NetWorkDemoAnalyse
{
    internal class OverrideSample
    {
        public void Foo(int value)
        {
            Console.WriteLine("Foo" + value);
        }
    }

    internal class Bar : OverrideSample
    {
        public void Foo(double value)
        {
            Console.WriteLine("BarDouble" + value);
        }

        public void Foo(int value)
        {
            Console.WriteLine("BarInt" + value);
        }
    }

    class Final
    {
        public void TestCode()
        {
            Bar bar = new Bar();
            bar.Foo(100);
        }
    }
}
