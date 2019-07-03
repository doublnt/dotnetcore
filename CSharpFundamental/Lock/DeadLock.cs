using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock
{
    internal class Account
    {
        internal uint Id { get; set; }
    }

    internal class DeadLock
    {
        // DeadLockDemo
        private static object lock_object = new object();
        private static int value1 = 100;
        private static int value2 = 200;

        // DeadLockDemo2
        private static readonly object _lock1 = new object();
        private static readonly object _lock2 = new object();

        public void ExecuteTheDeadLockDemo()
        {
            //DeadLockDemo2();
            //DeadLockDemo3(20);

            TestTheOutput();
        }

        private void TransferDemo(Account a1, Account a2)
        {

        }

        private Task ExecuteTransfer(Account a1, Account a2, int sum)
        {
            return Task.Run(() =>
            {

            });
        }

        private void TestTheOutput()
        {
            int a = 0;
            int b = 0;

            System.Threading.Tasks.Parallel.For(0, 100000, t =>
            {
                Interlocked.Increment(ref a);
            });
            Console.WriteLine(a);

            for (int i = 0; i < 100000; ++i)
            {
                b++;
            }

            Console.WriteLine(b);
        }

        private void DeadLockDemo3(int i)
        {
            lock (this)   //或者lock一个静态object变量
            {
                if (i > 10)
                {
                    Console.WriteLine(i--);
                    DeadLockDemo3(i);
                }
            }

        }

        private void DeadLockDemo2()
        {
            Task t1 = Task.Run(() =>
            {
                lock (_lock1)
                {
                    Thread.Sleep(1000);
                    lock (_lock2)
                    {
                        Console.WriteLine("Thread: {0} finished.", Thread.CurrentThread.ManagedThreadId);
                    }
                }
            });

            Task t2 = Task.Run(() =>
            {
                lock (_lock2)
                {
                    lock (_lock1)
                    {
                        Console.WriteLine("Thread: {0} is finished.", Thread.CurrentThread.ManagedThreadId);
                    }
                }
            });

            Task.WaitAll(t1, t2);
        }

        // Not Correct.
        private void DeadLockDemo()
        {
            int sum = 0;

            Task t1 = Task.Run(() =>
            {
                lock (lock_object)
                {
                    sum += value1;
                }
            });

            Task t2 = Task.Run(() =>
            {
                lock (lock_object)
                {
                    sum += value2;
                }
            });

            Task.WaitAll(t1, t2);

            Console.WriteLine(sum);
        }
    }
}
