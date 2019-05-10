using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

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
            //
            ThreadCancelTest();
            CancelRegister();
            LinkCancelTokenSource();
        }

        private void SuppressFlowTest()
        {
            CallContext.LogicalSetData("Name", "Robert");

            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name={0}", CallContext.LogicalGetData("Name")));

            ExecutionContext.SuppressFlow();

            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name={0}", CallContext.LogicalGetData("Name")));

            ExecutionContext.RestoreFlow();

            Console.ReadLine();
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
    }
}
