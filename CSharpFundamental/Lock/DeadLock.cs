using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
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
            DeadLockDemo2();
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
