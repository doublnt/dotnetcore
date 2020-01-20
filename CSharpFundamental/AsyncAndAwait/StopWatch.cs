using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.AsyncAndAwait
{
    public class StopWatch
    {
        public async void Run()
        {
            var task = TaskDelay();
            await task;

            Sync();
        }

        private async Task TaskDelay()
        {
            Console.WriteLine("Async:Start...");
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            Task delay = Task.Delay(5000);

            Console.WriteLine($"Async:Running for {stopWatch.Elapsed.TotalSeconds} seconds.");
            await delay;
            Console.WriteLine($"Async:Running for {stopWatch.Elapsed.TotalSeconds} seconds.");
            Console.WriteLine("Async:Done.");
        }

        private void Sync()
        {
            Console.WriteLine("Sync:Starting...");
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine($"Sync:Running for {stopWatch.Elapsed.TotalSeconds} seconds.");
            Console.WriteLine("Sync:Done");
        }
    }
}
