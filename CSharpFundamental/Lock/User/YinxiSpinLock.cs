﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock
{
    public struct YinxiSpinLock
    {
        // 0 stands false, while 1 stands for true.
        private int m_ResourceInUse;

        public void Enter()
        {
            while (true)
            {
                if (Interlocked.Exchange(ref m_ResourceInUse, 1) == 0)
                {
                    return;
                }
            }
        }

        public void Leave()
        {
            Volatile.Write(ref m_ResourceInUse, 0);
        }
    }
}
