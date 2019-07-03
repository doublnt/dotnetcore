using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock
{
    internal class YinXiMutex : IDisposable
    {
        private readonly Mutex m_lock = new Mutex();

        public void Dispose()
        {
            m_lock.Dispose();
        }

        public void Method1()
        {
            m_lock.WaitOne();
            // 执行一些线程安全的操作
            Method2();
            m_lock.ReleaseMutex();
        }

        public void Method2()
        {
            m_lock.WaitOne();
            m_lock.ReleaseMutex();
        }
    }
}
