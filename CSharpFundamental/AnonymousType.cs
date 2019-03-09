using System;
using System.Collections;

namespace CSharpFundamental
{
    public class AnonymousType
    {
        public delegate int CalNum(int x);

        public void CreateAnonymousAndExecute()
        {
            var family = new[] {
                new {Name = "John",Age = 20},
                new {Name = "Robert",Age =19}
            };

            var totalAge = 0;
            foreach (var person in family)
            {
                totalAge += person.Age;
            }
            System.Console.WriteLine(totalAge);

            var dictionary1 = new System.Collections.Generic.Dictionary<string, int>()
            {
              {"robert",11 },
              {"john",22}
            };

            CalNum delegateMethod = delegate (int x)
            {
                return x + 22;
            };

            System.Console.WriteLine(delegateMethod(333));

            Func<string, string, int> returnAInt = delegate (string num1, string num2)
            {
                return Convert.ToInt32(num1) + Convert.ToInt32(num2);
            };

            Func<string, string, int> returnAIntWithLambda1 = (string num1, string num2) =>
            {
                return Convert.ToInt32(num1) + Convert.ToInt32(num2);
            };

            Func<string, string, int> returnAIntWithLambda2 = (num1, num2) =>
             {
                 return Convert.ToInt32(num1) + Convert.ToInt32(num2);
             };

            Func<string, string, int> returnAIntWithLambda3 = (num1, num2) => Convert.ToInt32(num1) + Convert.ToInt32(num2);

            Func<string, int> returnAIntWithLambda4 = num1 => Convert.ToInt32(num1);

            System.Console.WriteLine(returnAInt("22", "33"));

            Action<string, string> NoReturnValue = delegate (string value1, string value2)
            {
                Console.WriteLine(value1 + value2);
            };

            NoReturnValue("xpy", "111");
        }
    }

    class XX
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}