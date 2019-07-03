using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock.Kernel
{
    /// <summary>
    /// WaitHandler 的 WaitOne 方法让调用线程等待底层内核对象收到信号，如果收到信息，返回 true，超时就返回false
    /// </summary>
    internal class YinXiRecursiveAutoResetEvent : IDisposable
    {
        private AutoResetEvent m_lock = new AutoResetEvent(true);
        private int m_owningThreadId = 0;
        private int m_recursionCount = 0;

        public void Enter()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;

            if (m_owningThreadId == currentThreadId)
            {
                m_recursionCount++;
                return;
            }

            // 调用线程不拥有锁，等待它
            m_lock.WaitOne();

            m_owningThreadId = currentThreadId;
            m_recursionCount = 1;
        }

        public void Leave()
        {
            if (m_owningThreadId != Thread.CurrentThread.ManagedThreadId)
            {
                throw new InvalidOperationException();
            }

            if (--m_recursionCount == 0)
            {
                m_owningThreadId = 0;
                m_lock.Set(); // 唤醒一个正在等待的线程，如果有的话。
            }
        }

        public void Dispose()
        {
            m_lock.Dispose();
        }
    }
}
