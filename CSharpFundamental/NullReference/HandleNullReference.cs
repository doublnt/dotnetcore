using System;

namespace CSharpFundamental.NullReference
{
    internal class HandleNullReference
    {
        public void DoTheNullConditions()
        {
            //HandleNullCondition();

            OverloadMethod(null);
        }

        /// <summary>
        ///     Unhandled Exception: System.NullReferenceException: Object reference not set to an instance of an object.
        /// </summary>
        private void HandleNullCondition()
        {
            object nullString = null;
            var areNullValuesEqual = nullString.Equals(null);

            Console.WriteLine(areNullValuesEqual);
        }

        private void HandleNullCondition2()
        {
        }

        /// <summary>
        ///     In general, the code will compile when one parameter type can be cast to the other one
        ///     (i.e. one is derived from the other).
        ///     The method with the more specific parameter type will be called.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private string OverloadMethod(object args)
        {
            Console.WriteLine("object params");
            return "object params";
        }

        /// <summary>
        /// Method1
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private string OverloadMethod(string args)
        {
            Console.WriteLine("string args");
            return "string args";
        }

        private string OverloadMethod(int args)
        {
            return "int value";
        }

        /// <summary>
        ///     Method2, Method1 and Method2 can not be exist either, as it can not be compile.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        //private string OverloadMethod(NullClassTest args)
        //{
        //    return "NullClassTest args";
        //}
    }

    internal class NullClassTest
    {
    }
}