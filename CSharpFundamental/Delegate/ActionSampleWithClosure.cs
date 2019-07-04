using System;
using System.Threading;

namespace CSharpFundamental
{
    internal class ActionSampleWithClosure
    {
        internal void TimeCallbackFunc()
        {
            Action action;

            while ((action = PopWithPushNext(DateTime.Now)) != null)
            {
                //var action1 = new Action(action);
                ThreadPool.QueueUserWorkItem(state => action());
            }

            //ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Hello,This is my function= {0}", state), DateTime.Now);
        }

        private Action PopWithPushNext(object value)
        {
            var date = (DateTime)value;
            return () => { Console.WriteLine("Current Time is ={0}", date); };
        }

        public void TestAction()
        {
            Action<string> action1 = (a) => Console.WriteLine(a + "10086");

            action1("Hello, world");

            Func<string, string> func1 = (a) => a + "100086" + "string";

            var value1 = func1("Hello, World");

            Console.WriteLine(value1);
        }
    }
}
