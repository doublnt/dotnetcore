using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFundamental.ExpressionTree
{
    public class ExtendsMethodExprssionTree
    {
        private List<People> peoples;
        private Dictionary<string, string> queryData;


        public void PrintEnumerable()
        {
            InitializeData();

            //EnumerableMethod();

            LinqToObject();
        }

        private void InitializeData()
        {
            queryData = new Dictionary<string, string>
            {
                {"key1", "value1"},
                {"key2", "value2"},
                {"key3", "value3"}
            };

            peoples = new List<People>
            {
                new People
                    {Age = 10, Name = "Mike"},
                new People
                    {Age = 29, Name = "Robert"},
                new People
                    {Age = 30, Name = "Jenny"}
            };
        }

        private void EnumerableMethod()
        {
            foreach (var i in Enumerable.Range(1, 20))
            {
                Console.WriteLine(i);
            }
        }

        private void LinqToObject()
        {
            // Will return IEnumerable<string> collection
            var value = from people in peoples
                        where people.Name == "Mike"
                        select people.Age;

            Console.WriteLine(value.FirstOrDefault());
        }

        private string RefMethod(ref string value)
        {
            return value;
        }

        private string OutMethod(out string value)
        {
            value = "10086";
            return value;
        }
    }

    internal class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
