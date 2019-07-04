using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock.Hybird
{
    internal class YinXiReaderWriterLockSlim
    {
        private readonly ReaderWriterLockSlim m_lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private DateTime m_timeOfLastTrans;

        public void PerformTransaction()
        {
            m_lock.EnterWriteLock();

            m_timeOfLastTrans = DateTime.Now;

            m_lock.ExitWriteLock();
        }

        public DateTime LastTransaction
        {
            get
            {
                m_lock.EnterReadLock();

                DateTime temp = m_timeOfLastTrans;

                m_lock.ExitReadLock();

                return temp;
            }
        }
    }
}
