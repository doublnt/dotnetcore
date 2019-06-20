using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Console = System.Console;

namespace CSharpFundamental.Dynamic
{
    internal class DynamicSample
    {
        public void DynamicExecute()
        {
            var type1 = typeof(PrivateClass);

            Console.WriteLine(type1.FullName);

            var privateClass = Activator.CreateInstance(type1);

            Console.WriteLine(privateClass.GetType());

            dynamic test = "10086";
            Console.WriteLine(test);
            test = 11;
            Console.WriteLine(test);

            dynamic tempValue = new PrivateClass("Robert.M.XiYin", "10086", "121312231");

            Console.WriteLine(tempValue.Version);
        }
    }
}
