using System;

namespace CSharpFundamental.keywork
{
    //默认为  internal 类型，当前 程序集可见
    class TestClass
    {
        //字段默认为 private 类型，只允许该类和嵌套类访问
        Int32 age;


        //方法未申明任何 关键字 默认为 private  当前类访问级别
        void DoActionWithThing1()
        {

        }
    }

    internal class AbstractAndVirtualKeywords
    {
        /// <summary>
        /// abstract method in non-abstract class and you should use interface
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        //public abstract Int32 AbstractCalculateSum(Int32 x1, Int32 x2);

        public Int32 CalculateValue(Int32 x1, Int32 x2)
        {
            return x1 + x2;
        }

        /// <summary>
        /// Can be override
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public virtual Int32 CalculateValue1(Int32 x1, Int32 x2)
        {
            return x1 + x2;
        }

        public void DoThing()
        {
            //Can not be create
            //var class1 = new AbstractClass();
        }
    }

    internal class InheritedFromAbstractAndVirtualKeywords : AbstractAndVirtualKeywords
    {
        //What different between override and new when override a base method

        /// <summary>
        /// new 表示当前这个方法完全是全新的实现，和 base 类(基类)的方法无任何关系，可以通过
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public new Int32 CalculateValue2(Int32 x1, Int32 x2)
        {
            return x1 + 10086;
        }

        public override int CalculateValue1(int x1, int x2)
        {
            return x1 + x2 + 10086;
        }


    }

    //Can not be create the instance, you should inherited and implement it.
    internal abstract class AbstractClass
    {
        public abstract Int32 AbstractCalculateValue(Int32 x);

        public Int32 CalculateValue(Int32 x)
        {
            return x;
        }
    }

    internal class InheritedFromAbstract : AbstractClass
    {
        //Should be add < override > explicitly
        public override Int32 AbstractCalculateValue(Int32 x)
        {
            return x;
        }
    }

    internal sealed class SealedClass
    {
        public void DoSealThing()
        {
            Console.WriteLine("Hello,World");
        }
    }

    //Can not inherited sealed type class
    //internal class InheritedSealedClass :SealedClass 

    internal class Employee
    {
        public Int32 GetYearsEmployed()
        {
            return 11;
        }

        public virtual String GetProgessReporrt()
        {
            return "Progress";
        }

        public static Employee Lookup(String name)
        {
            return new Employee();
        }
    }
}
