using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.AsyncCoordinator
{
    internal sealed class AsyncCoordinator
    {
        private Int32 m_opCount = 1;
        private Int32 m_statusReported = 0; //0 代表 false， 1 代表 true
        private Action<CoordinationStatus> m_callback;
        private System.Threading.Timer m_timer;

        public void AboutToBegin(Int32 opsToAdd = 1)
        {
            Interlocked.Add(ref m_opCount, opsToAdd);
        }

        public void JustEnded()
        {
            if (Interlocked.Decrement(ref m_opCount) == 0)
            {
                //当所有异步操作都完成，调用 ReportStatus 通知它已全部完成
                ReportStatus(CoordinationStatus.AllDone);
            }
        }

        public void AllBegun(Action<CoordinationStatus> callback, Int32 timeout = Timeout.Infinite)
        {
            m_callback = callback;

            if (timeout != Timeout.Infinite)
            {
                m_timer = new System.Threading.Timer(TimeExpired, null, timeout, Timeout.Infinite);
            }

            JustEnded();
        }

        private void TimeExpired(Object o)
        {
            ReportStatus(CoordinationStatus.Timeout);
        }

        public void Cancel()
        {
            ReportStatus(CoordinationStatus.Cancel);
        }

        /// <summary>
        /// 对全部操作结束，发生超时，调用Cancel 时可能发生的竞态条件进行仲裁。
        /// </summary>
        /// <param name="status"></param>
        private void ReportStatus(CoordinationStatus status)
        {
            if (Interlocked.Exchange(ref m_statusReported, 1) == 0)
            {
                m_callback(status);
            }
        }
    }
}
