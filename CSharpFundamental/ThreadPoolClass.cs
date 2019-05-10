using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
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


            SuppressFlowTest();
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
    }
}
