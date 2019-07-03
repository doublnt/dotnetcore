using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock
{
    internal class YinXiEventWaitLock : IDisposable
    {
        /// <summary>
        /// 事件由内核 维护 的 bool 变量，事件为 false，在事件上等待的线程就阻塞，反之，解除阻塞。
        /// </summary>

        private readonly AutoResetEvent m_available;

        public YinXiEventWaitLock()
        {
            m_available = new AutoResetEvent(true);
        }

        public void Enter()
        {
            m_available.WaitOne();
        }

        public void Leave()
        {
            // 将 boolean 设为 true，总是返回 true
            m_available.Set();

            // Reset()，将 boolean 设为 false，总是返回 true
        }

        public void Dispose()
        {
            m_available.Dispose();
        }
    }
}
