using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.TaskTest
{
    public class TaskDemo
    {
        public async void Run()
        {
            var task = Enumerable.Range(0, 10).Select(i => Task.Run(() => LongTimeTask(i))).ToList();

            await Task.WhenAll(task);

            Console.ReadLine();
        }

        private static void LongTimeTask(int i)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId.ToString().PadLeft(2, ' ');
            var line = i.ToString().PadLeft(2, ' ');

            //Console.WriteLine($"[{line}] [{threadId}] [{TaskScheduler.Default}]");
            Console.WriteLine($"[{line}] [{threadId}] [{DateTime.Now:yyyyMMddHHmmss.fff}] 异步任务已开始。。。");

            Thread.Sleep(5000);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{line}] [{threadId}] [{DateTime.Now:yyyyMMddHHmmss.fff}] 异步任务已结束。。。");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
