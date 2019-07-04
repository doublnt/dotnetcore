using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock.Hybird
{
    internal class YinXiHybirdLock : IDisposable
    {
        private int m_waiters = 0;

        private AutoResetEvent m_waiterLock = new AutoResetEvent(false);

        public void Enter()
        {
            // 指出这个线程想要获得锁。
            if (Interlocked.Increment(ref m_waiters) == 1)
            {
                return; // 锁可自由使用，无竞争，直接返回。
            }

            // 另一个线程拥有锁（发生竞争），使这个线程等待
            m_waiterLock.WaitOne();
        }

        public void Leave()
        {
            if (Interlocked.Decrement(ref m_waiters) == 0)
            {
                return;
            }

            // 有其他线程正在阻塞，唤醒其中一个
            m_waiterLock.Set();
        }

        public void Dispose()
        {
            m_waiterLock.Dispose();
        }
    }
}
