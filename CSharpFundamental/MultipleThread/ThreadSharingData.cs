using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class ThreadSharingData
    {
        private Int32 m_flag = 0;
        private Int32 m_value = 0;

        public void Thread1()
        {
            m_flag = 1;
            m_value = 5;
        }

        public void VolatileThread1()
        {
            m_flag = 1;
            Volatile.Write(ref m_value, 5);//ref 代表执行完这个方法， m_value 必须已经赋值完成
        }

        public void Thread2()
        {
            if (m_flag == 1)
                Console.WriteLine(m_value);
        }

        public void VolatileThread2()
        {
            if (Volatile.Read(ref m_value) == 1)
            {
                Console.WriteLine(m_value);
            }
        }

        public void DoThreadThing1()
        {
            Thread t1 = new Thread(Thread1);
            Thread t2 = new Thread(Thread2);

            t1.Start();
            t2.Start();


            t1.Join();
            t2.Join();
        }

        public void DoThreadThing2()
        {
            Thread t1 = new Thread(VolatileThread1);
            Thread t2 = new Thread(VolatileThread2);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }
}
