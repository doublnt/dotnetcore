using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AsyncAndSyncTest
{
    public class FrontAndBackEndThread
    {
        public void ExecuteThread()
        {
            Thread t = new Thread(Work);

            t.IsBackground = true;

            t.Start();

            Console.WriteLine("Returning from main");

            t.IsBackground = false;
            Console.WriteLine("Returning from main");
        }

        public void Work()
        {
            Thread.Sleep(10000);

            Console.WriteLine("Returning from worker");
        }
    }
}
