using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock
{
    internal class YinXiSemaphore
    {
        private Semaphore m_available;

        /// <summary>
        /// 信号量其实就是维护内核 int 变量，信号量为 0 时，在信号量上等待的线程会阻塞；
        /// 信号量大于 0 时，解除阻塞。在信号量上等待的线程解除阻塞时，内核自动从信号量计数减 1
        ///
        /// 所有线程已只读方式访问资源时，是安全的。
        /// </summary>
        /// <param name="maxConcurrent"></param>
        public YinXiSemaphore(int maxConcurrent)
        {
            m_available = new Semaphore(maxConcurrent, maxConcurrent);
        }

        public void Enter()
        {
            m_available.WaitOne();
        }

        public void Leave()
        {
            // Release(1) 返回上一个计数
            m_available.Release(1);
        }

        public void Dispose()
        {
            m_available.Dispose();
        }
    }
}
