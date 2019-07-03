using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock
{
    internal class LockBenchmark
    {
        public void RunBenchmark()
        {
            int x = 0;
            const int iteration = 10000000;

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < iteration; ++i)
            {
                ++x;
            }

            Console.WriteLine("{0:N0}", sw.ElapsedMilliseconds);

            sw.Restart();

            for (int i = 0; i < iteration; ++i)
            {
                DoNothing();
                x++;
                DoNothing();
            }

            Console.WriteLine(sw.ElapsedMilliseconds);

            SpinLock sl = new SpinLock(false);
            sw.Restart();
            for (int i = 0; i < iteration; ++i)
            {
                bool taken = false;
                sl.Enter(ref taken);
                x++;
                sl.Exit();
            }

            Console.WriteLine(sw.ElapsedMilliseconds);

            using (SimpleWaitLock simpleWaitLock = new SimpleWaitLock())
            {
                sw.Restart();
                for (int i = 0; i < iteration; ++i)
                {
                    simpleWaitLock.Enter();
                    x++;
                    simpleWaitLock.Leave();
                }

                Console.WriteLine(sw.ElapsedMilliseconds);
            }
        }

        private void DoNothing()
        {

        }
    }

    internal class SimpleWaitLock : IDisposable
    {
        private readonly AutoResetEvent m_available;

        public SimpleWaitLock()
        {
            m_available = new AutoResetEvent(true);
        }

        public void Enter()
        {
            m_available.WaitOne();
        }

        public void Leave()
        {
            m_available.Set();
        }

        public void Dispose()
        {
            m_available.Dispose();
        }
    }
}
