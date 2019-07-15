using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.MultipleThread.Book
{
    class TaskDelayDemo
    {
        public async Task DoSomethingAsync()
        {
            int val = 21;

            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            val *= 2;

            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            Trace.WriteLine(val.ToString());
        }

        public async Task DoAnotherThing()
        {
            Task.Factory.StartNew(() => Console.WriteLine("Hello,World.")).Wait();
        }
    }
}
