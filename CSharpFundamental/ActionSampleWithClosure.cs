using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class ActionSampleWithClosure
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

        Action PopWithPushNext(object value)
        {
            var date = (DateTime)value;
            return () => { Console.WriteLine("Current Time is ={0}", date); };

        }
    }
}
