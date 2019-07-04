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
        /// 有两种事件，即自动重置事件和手动重置事件。当一个自动重置事件为 true 时，它只唤醒一个阻塞的
        /// 线程，因为在解除第一个线程的阻塞后，内核将事件自动重置为 false，造成其余线程继续阻塞。而当
        /// 一个手动重置事件为 true 时，它解除正在等待它的所有线程的阻塞，因为内核不将事件自动重置为 false，
        /// 必须手动重置为 false。
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
