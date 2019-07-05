using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.MultipleThread
{
    class MultipleThreadAddDemo
    {
        public void RunTheLogic()
        {
            int taskCount = 1000;
            Task[] tasks = new Task[taskCount];

            for (int i = 0; i < taskCount; ++i)
            {
                tasks[i] = Task.Run(Calculate);
            }

            Task.WaitAll(tasks);
            Console.WriteLine(PersonAge.age);
        }

        private void Calculate()
        {
            Interlocked.Increment(ref PersonAge.age);
        }
    }

    class PersonAge
    {
        public static volatile int age = 0;
    }
}
