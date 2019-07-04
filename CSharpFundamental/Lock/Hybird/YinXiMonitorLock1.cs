using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock.Hybird
{
    internal class YinXiMonitorLock1
    {
        private DateTime m_timeofLastTrans;

        public void PerformTransaction()
        {
            Monitor.Enter(this);
            m_timeofLastTrans = DateTime.Now;
            Monitor.Exit(this);
        }

        public DateTime LastTransaction
        {
            get
            {
                Monitor.Enter(this);
                DateTime temp = m_timeofLastTrans;
                Monitor.Exit(this);

                return temp;
            }
        }
    }

    internal class YinXiMonitorLock2
    {
        // 使用私有锁
        public object m_lock = new object();
        private DateTime m_timeOfLastTrans;

        public void PerformTransaction()
        {
            Monitor.Enter(m_lock);
            m_timeOfLastTrans = DateTime.Now;
            Monitor.Exit(m_lock);
        }

        public DateTime LastTransaction
        {
            get
            {
                Monitor.Enter(m_lock);
                DateTime temp = m_timeOfLastTrans;
                Monitor.Exit(m_lock);

                return temp;
            }
        }

    }


    internal class TestTransaction
    {
        public void TransactionTest()
        {
            var t = new YinXiMonitorLock1();
            Monitor.Enter(t);

            ThreadPool.QueueUserWorkItem(a => Console.WriteLine(t.LastTransaction));

            Monitor.Exit(t);
        }
    }
}
