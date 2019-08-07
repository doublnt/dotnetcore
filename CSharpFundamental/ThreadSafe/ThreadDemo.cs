using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.ThreadSafe
{
    class ThreadDemo
    {
        private int value = 0;

        public void StartThreadManually()
        {
            Thread thread = new Thread(AddValue);

            thread.Name = "Current";
            thread.Start();

            thread.Priority = ThreadPriority.Highest;

            Console.WriteLine("Are running in background: " + thread.IsBackground);


            var threadState = thread.ThreadState;
            while (threadState == ThreadState.Stopped)
            {
                Console.WriteLine(value);

                threadState = thread.ThreadState;
            }

            Console.ReadKey();
        }

        private void AddValue()
        {
            value++;
        }
    }
}
