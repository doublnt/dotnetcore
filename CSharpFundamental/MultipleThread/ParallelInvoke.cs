using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private async void RunTheTaskRunWithWhenAll()
        {
            Console.WriteLine("-----Task Run-----When ALL");

            Task[] tasks = new Task[CurrentThreadNumber];

            for (int i = 0; i < CurrentThreadNumber; ++i)
            {
                tasks[i] = Task.Run(PrintTheCurrentTaskId);
            }

            await Task.WhenAll(tasks);
        }

        private void RunTheTaskRunWithWaitAll()
        {
            Console.WriteLine("-----Task Run-----Wait ALL");

            Task[] tasks = new Task[CurrentThreadNumber];

            for (int i = 0; i < CurrentThreadNumber; ++i)
            {
                tasks[i] = Task.Run(PrintTheCurrentTaskId);
            }

            Task.WaitAll(tasks);
        }

        private void ContinueTaskDemo()
        {
            Task task = Task.Run(PrintTheCurrentTaskId);
            task.ContinueWith(t => ContinueTask());

            task.Wait();
        }

        public void RunTheThread()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            RunTheTaskRunWithWhenAll();
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        private async Task<int> ReturnAsyncValue()
        {
            await Task.Delay(1000);

            return 1;
        }
    }
}
