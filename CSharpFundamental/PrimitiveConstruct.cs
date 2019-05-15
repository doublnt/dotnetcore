using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class PrimitiveConstruct
    {
        private static Boolean s_stopWorker = false;

        public void DoWorkerThing()
        {
            Console.WriteLine("Main: letting worker run for 5 seconds");

            Thread t = new Thread(Worker);
            t.Start();
            Thread.Sleep(5000);

            s_stopWorker = true;

            Console.WriteLine("Main: waiting for worker to stop");
            t.Join();
        }

        public void Worker(Object o)
        {
            Console.WriteLine("Current Managed Id = {0}", Thread.CurrentThread.ManagedThreadId);

            Int32 x = 0;
            while (!s_stopWorker) x++;
            Console.WriteLine("Worker: stopped when x = {0}", x);
        }
    }
}
