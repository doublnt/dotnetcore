using System;
using System.Threading;

namespace CSharpFundamental.AsyncCoordinator
{
    internal sealed class AsyncCoordinator
    {
        private Action<CoordinationStatus> m_callback;
        private int m_opCount = 1;
        private int m_statusReported; //0 代表 false， 1 代表 true
        private Timer m_timer;

        public void AboutToBegin(int opsToAdd = 1)
        {
            Interlocked.Add(ref m_opCount, opsToAdd);
            // Interlocked.Increment(ref m_opCount);
        }

        public void JustEnded()
        {
            if (Interlocked.Decrement(ref m_opCount) == 0)
            {
                //当所有异步操作都完成，调用 ReportStatus 通知它已全部完成
                ReportStatus(CoordinationStatus.AllDone);
            }
        }

        public void AllBegun(Action<CoordinationStatus> callback, int timeout = Timeout.Infinite)
        {
            m_callback = callback;

            if (timeout != Timeout.Infinite)
            {
                m_timer = new Timer(TimeExpired, null, timeout, Timeout.Infinite);
            }

            JustEnded();
        }

        private void TimeExpired(object o)
        {
            ReportStatus(CoordinationStatus.Timeout);
        }

        public void Cancel()
        {
            ReportStatus(CoordinationStatus.Cancel);
        }

        /// <summary>
        ///     对全部操作结束，发生超时，调用Cancel 时可能发生的竞态条件进行仲裁。
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
