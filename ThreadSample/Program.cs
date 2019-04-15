using System;
using System.Runtime;
using System.Threading;

namespace ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Timer t = new Timer(TimerCallBack, null, 0, 2000);

            //Console.ReadLine();

            //t.Dispose();

            Console.WriteLine("Application is runnning with server GC=" + GCSettings.IsServerGC);

        }

        public static void TimerCallBack(Object o)
        {
            Console.WriteLine("In TimerCallBack: " + DateTime.Now);

            GC.Collect();
        }
    }
}
