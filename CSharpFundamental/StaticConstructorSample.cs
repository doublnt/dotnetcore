using System;

namespace CSharpFundamental
{
    public class StaticConstructorSample
    {
        public string str = "TestConstructor";
        public int num = 2;

        public static int staticVariable = 10086;

        static StaticConstructorSample()
        {
            staticVariable = 10087;
        }

        public StaticConstructorSample()
        {
            num = 3;
        }


        /// <summary>
        ///     Static varibel -> static Constructor -> instance variable -> instance constructor
        /// </summary>
        public void PrintTheStaticValue()
        {
            Console.WriteLine(staticVariable);

            Console.WriteLine(num);
        }

        public static void StaticMethod(string args)
        {

        }

        public static void StaticMethod(string args, int age)
        {

        }
    }
}
