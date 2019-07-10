using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.NetWorkDemoAnalyse
{
    class AnonymousDemo
    {
        public void DoTheAnonymousSample()
        {
            List<Action> actions = new List<Action>();

            actions.Add(() => Console.WriteLine("A"));
            actions.Add(() => Console.WriteLine("B"));
            actions.Add(() => Console.WriteLine("C"));
            actions.Add(() => Console.WriteLine("D"));

            foreach (var action in actions)
            {
                ThreadPool.QueueUserWorkItem(state => action(), null);
            }

            int threads;
            int compleationPortThreads;
            ThreadPool.GetMaxThreads(out threads, out compleationPortThreads);
            Console.WriteLine(threads + "|" + compleationPortThreads);
        }
    }
}
