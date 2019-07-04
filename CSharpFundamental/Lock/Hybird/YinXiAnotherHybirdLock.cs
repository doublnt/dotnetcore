using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock.Hybird
{
    internal class YinXiAnotherHybirdLock : IDisposable
    {
        private int m_waiters = 0;

        // 为什么为 false，false 表示阻塞线程
        private AutoResetEvent m_waitLock = new AutoResetEvent(false);

        // 控制自旋次数
        private int m_spinCount = 4000;

        private int m_owningThreadId = 0;
        private int m_recursion = 0;

        public void Enter()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;

            if (currentThreadId == m_owningThreadId)
            {
                m_recursion++;
                return;
            }

            SpinWait spinWait = new SpinWait();

            for (int spinCount = 0; spinCount < m_spinCount; ++spinCount)
            {
                if (Interlocked.CompareExchange(ref m_waiters, 1, 0) == 0)
                {
                    goto GotLock;
                }

                // 给其他线程机会，希望锁会释放。
                spinWait.SpinOnce();
            }

            // 自旋结束，仍未获得锁，再试一次。
            if (Interlocked.Increment(ref m_waiters) > 1)
            {
                m_waitLock.WaitOne();
            }

            GotLock:
            // 一个线程获得锁时，我们记录其线程 ID 和 这个线程获得锁的次数。
            m_owningThreadId = currentThreadId;
            m_recursion = 1;
        }

        public void Leave()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;

            if (currentThreadId != m_owningThreadId)
            {
                throw new SynchronizationLockException("Lock not owned by calling thread.");
            }

            if (--m_recursion > 0)
            {
                return;
            }

            m_owningThreadId = 0;

            if (Interlocked.Decrement(ref m_waiters) == 0)
            {
                return;
            }

            m_waitLock.Set();
        }

        public void Dispose()
        {
            m_waitLock.Dispose();
        }
    }
}
