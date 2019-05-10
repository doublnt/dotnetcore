using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    public class ThreadPoolClass
    {
        private void ThreadPoolTest()
        {
            var threadPool1 = ThreadPool.QueueUserWorkItem(PrintTheSystemInfo, 5);
            var threadPool2 = ThreadPool.UnsafeQueueUserWorkItem(PrintTheSystemInfo, 6);

            ThreadPool.SetMaxThreads(10, 5);
            ThreadPool.SetMinThreads(5, 2);
        }

        //The WaitCallBack Delegate demo is delegate void WaitCallBack(Object state)
        private void PrintTheSystemInfo(Object state)
        {
            Console.WriteLine("In PrintTheSystemInfo: state={0}", state);
            Console.WriteLine(Environment.OSVersion);

            Thread.Sleep(1000);
        }

        public void MonitorTheThreadPool()
        {
            //            Console.WriteLine("Main Thread: queuing an asynchronous operation");
            //            ThreadPool.QueueUserWorkItem(PrintTheSystemInfo, 5);
            //
            //            Console.WriteLine("Main thread: Doing other work here....");
            //
            //            Thread.Sleep(5000);
            //
            //            Console.WriteLine("Hit <Enter> to end this program...");


            //            SuppressFlowTest();
            //            ThreadCancelTest();
            //            CancelRegister();
            //            LinkCancelTokenSource();

            //            DoTaskSum();
            //            DoWithTheMaxAndMinThread();

            Console.WriteLine("Get The Main Thread ID={0}", Thread.CurrentThread.ManagedThreadId);
            ThreadPool.QueueUserWorkItem(CallbackFunc, 1000);

            //Output the max threads and max compleetion port thread
            //....
            //ThreadPool.GetMaxThreads(out int maxThreads, out int maxcompletionPortThread);
            //System.Console.WriteLine(maxThreads + "||||" + maxcompletionPortThread);

            Task t1 = Task.Run(() => Console.WriteLine("Do the task run things={0}", 10086));

            //for (Int32 i = 0; i < 20; i++)
            //{
            //    Int32 temp = i;
            //    var t3 = Task.Run(() => CallbackFunc(temp));
            //}

            Task<Int32> t2 = new Task<Int32>(n => Sum((Int32)n), 1000);
            t2.Start();
            t2.Wait();
            Console.WriteLine(t2.Result);

            //Continue Task Demo
            CancellationTokenSource cts = new CancellationTokenSource();
            //cts.Cancel();

            Task t3 = Task.Run(() =>
            {
                Console.WriteLine("This is a main continue demo1");
                Thread.Sleep(5000);
            }, cts.Token);
            Console.WriteLine("Current Task status= {0}", t3.Status);//Waiting to run
            t3.ContinueWith(task => Console.WriteLine("This is a method only main func is canceled"), TaskContinuationOptions.OnlyOnCanceled);
            Console.WriteLine("Current Task status= {0}", t3.Status);//Running
            t3.ContinueWith(task =>
            {
                Console.WriteLine("This is method only run to completion");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Console.WriteLine("Current Task status= {0}", t3.Status);//Running

            //Task<Int32[]> parent = new Task<Int32[]>(() =>
            //{
            //    var results = new Int32[3];

            //    new Task(() => results[0] = Sum(10000), TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[1] = Sum(20000), TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[2] = Sum(30000), TaskCreationOptions.AttachedToParent).Start();

            //    return results;
            //});

            //var cwt = parent.ContinueWith(parentTask => Array.ForEach(parentTask.Result, Console.WriteLine));
            //parent.Start();

            //如果不用readline，屏幕上会没有任何输出，因为 CallbackFunc 通过线程池来执行，
            //执行它的线程可能不是当前线程，而且又是异步的,屏幕上就会没有任何输出。
            Console.ReadLine();
        }

        private void DoWithTheMaxAndMinThread()
        {
            ThreadPool.SetMaxThreads(100, 100);
            ThreadPool.SetMinThreads(5, 5);

            //            WaitCallback callback = index =>
            //            {
            //                Console.WriteLine("Start--------------{0}", index);
            //
            //                Thread.Sleep(1000);
            //
            //                Console.WriteLine("--------------End-{0}", index);
            //            };
            //
            //            for (int i = 0; i < 20; i++)
            //            {
            //                ThreadPool.QueueUserWorkItem(callback, i);
            //            }

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => CallbackFunc(i));
            }
        }

        private void CallbackFunc(Object state)
        {
            Console.WriteLine("Get The CallbackFunc current Thread ID={0}", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Start--------------{0}", state);

            Thread.Sleep(1000);

            Console.WriteLine("--------------End-{0}", state);
        }

        private void SuppressFlowTest()
        {
            CallContext.LogicalSetData("Name", "Robert");

            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name={0}", CallContext.LogicalGetData("Name")));

            ExecutionContext.SuppressFlow();

            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name={0}", CallContext.LogicalGetData("Name")));

            ExecutionContext.RestoreFlow();

            //            Console.ReadLine();
            //Use task to do the same thing

            new Task(() => Console.WriteLine("Hello,World")).Start();
            Task.Run(() => Console.WriteLine("Hello,World Second version."));
            Task.Run(() => Console.WriteLine("Version three just for consturctor"), CancellationToken.None);
        }

        private void ThreadCancelTest()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            ThreadPool.QueueUserWorkItem(state => Count(cts, 100));

            Console.WriteLine("Press <Enter to cancel the operation>");

            Console.ReadLine();
            cts.Cancel();

            Console.ReadLine();
        }

        private void Count(CancellationTokenSource cancellationTokenSource, Int32 countTo)
        {
            cancellationTokenSource.Token.Register(() => Console.WriteLine("Hahaha, Callback function is back"));

            for (Int32 count = 0; count < countTo; count++)
            {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled!");
                    break;
                }

                Console.WriteLine(count);
                Thread.Sleep(200);
            }

            Console.WriteLine("Count is done!");
        }

        private void CancelRegister()
        {
            var cts = new CancellationTokenSource();

            cts.Token.Register(() => Console.WriteLine("Canceled 1"));
            cts.Token.Register(() => Console.WriteLine("Canceled 2"));

            cts.Cancel();
        }

        private void LinkCancelTokenSource()
        {
            var cts1 = new CancellationTokenSource();
            cts1.Token.Register(() => Console.WriteLine("cts1 canceled"));

            var cts2 = new CancellationTokenSource();
            cts2.Token.Register(() => Console.WriteLine("cts2 canceled"));

            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);
            linkedCts.Token.Register(() => Console.WriteLine("LinkedCts canceled"));


            cts2.Cancel();

            Console.WriteLine("Cts1 canceled={0}, Cts2 canceled={1} linkedCts canceled={2}",
                cts1.IsCancellationRequested, cts2.IsCancellationRequested, linkedCts.IsCancellationRequested);
        }

        private Int32 Sum(Int32 n)
        {
            //Calculate the n + n-1 + ...+1
            Int32 sum = 0;

            for (; n > 0; n--)
            {
                checked
                {
                    sum += n;
                }
            }

            return sum;
        }

        private Int32 SumWithCancelToken(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0;

            for (; n > 0; n--)
            {
                ct.ThrowIfCancellationRequested();

                checked
                {
                    sum += n;
                }
            }

            return sum;
        }

        public void DoTaskSum()
        {
            //Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 10);

            //Task t2 = new Task(() => Console.WriteLine("Hello,World!"));

            //t.Start();

            //t.Wait();

            //Console.WriteLine("The sum is:" + t.Result);

            //CancellationTokenSource cts = new CancellationTokenSource();

            //Task<Int32> t3 = new Task<Int32>(n => SumWithCancelToken(cts.Token, (Int32)n), 10000);
            //t3.Start();
            //Equal to the following

            //Task<Int32> t3 = Task.Run(() => SumWithCancelToken(cts.Token, 10000), cts.Token);

            //Task cwt = t3.ContinueWith(task => Console.WriteLine("Hello,The sum is:" + task.Result));

            //cts.Cancel();

            //try
            //{
            //    Console.WriteLine("The sum is:", t3.Result);
            //    Console.WriteLine();
            //}
            //catch (AggregateException ex)
            //{
            //    ex.Handle(e => e is OperationCanceledException);

            //    Console.WriteLine("Sum was canceled");
            //}


            CancellationTokenSource cts = new CancellationTokenSource();

            Task<Int32> t4 = Task.Run(() => Sum(10000));

            t4.ContinueWith(task => Console.WriteLine("Hello, this is continue with function= {0}", task.Result), TaskContinuationOptions.ExecuteSynchronously);
            t4.ContinueWith(task => Console.WriteLine("Sum was canceled"), TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine(t4.Result);
        }
    }
}
