using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.MultipleThread
{
    internal class ParallelInvoke
    {
        private const int CurrentThreadNumber = 10;

        private void PrintTheCurrentTaskId()
        {
            Console.WriteLine($"Current Task Id={Thread.CurrentThread.ManagedThreadId}");
        }

        private void ContinueTask()
        {
            Console.WriteLine("This is a continue task.");
        }

        private void RunTheParallelInvoke()
        {
            Console.WriteLine("-----Parallel Invoke-----");

            Action[] actions = new Action[CurrentThreadNumber];

            for (int i = 0; i < CurrentThreadNumber; ++i)
            {
                actions[i] = PrintTheCurrentTaskId;
            }

            Parallel.Invoke(actions);
        }

        private void RunTheTaskRun()
        {
            Console.WriteLine("-----Task Run-----");

            Task[] tasks = new Task[CurrentThreadNumber];

            for (int i = 0; i < CurrentThreadNumber; ++i)
            {
                tasks[i] = Task.Run(PrintTheCurrentTaskId);
            }

            Task.WhenAll(tasks);
        }

        private void ContinueTaskDemo()
        {
            Task task = Task.Run(PrintTheCurrentTaskId);
            task.ContinueWith(t => ContinueTask());

            task.Wait();
        }

        public void RunTheThread()
        {
            //RunTheParallelInvoke();

            //RunTheTaskRun();

            ContinueTaskDemo();

            Console.ReadKey();
        }
    }
}
