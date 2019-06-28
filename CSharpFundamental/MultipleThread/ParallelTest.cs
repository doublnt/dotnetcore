using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    public class ParallelTest
    {
        private int workerThreads;
        private int completionPortThreads;
        private int availableWorkerThreads;
        private int availCompletionPortThreads;

        public void Parallel1()
        {
            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine("The max threads={0}\t the completion port threads={1}", workerThreads, completionPortThreads);

            //            Parallel.For(0, 10000, index => Sum(index));

            //Parallel.ForEach use for collections situation

            List<string> aList = new List<string> { "Test1", "Test2", "Test3" };

            var parallelLoopResult = Parallel.ForEach(aList, item => PrintTheList(item));
            Console.WriteLine(parallelLoopResult.IsCompleted);

            //Parallel.Invoke,同样是在线程池中执行，没有先后顺序。

            Parallel.Invoke(
                () => ExecuteMethod1(),
                () => ExecuteMethod2(),
                () => ExecuteMethod3());


        }

        private int Sum(Int32 number)
        {
            ThreadPool.GetAvailableThreads(out availableWorkerThreads, out availCompletionPortThreads);
            Int32 sum = 0;
            for (; number > 0; number--)
            {
                sum += number;
                Console.WriteLine("The available threads={0}\t the available completion port threads={1}", availableWorkerThreads, availCompletionPortThreads);
            }

            return sum;
        }

        private void PrintTheList(String item)
        {
            Console.WriteLine(item);
        }

        private void ExecuteMethod1()
        {
            Console.WriteLine("First Print.");
        }

        private void ExecuteMethod2()
        {

            Console.WriteLine("Second Print!");
        }

        private void ExecuteMethod3()
        {
            Console.WriteLine("Thrid Print!");
        }
    }
}
