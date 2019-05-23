using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class MultipleThreadCompete
    {
        List<int> numList = new List<int>();
        Random random = new Random();
        CancellationTokenSource cts = new CancellationTokenSource();
        private const int ENDNUM = 100000;

        ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

        internal void DoTheCompeteSecond()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task[] tasks = new Task[100];

            for (int i = 0; i < 100; ++i)
            {
                int num = i;
                tasks[i] = Task.Run(() => AddNumToList(num, cts), cts.Token);
            }

            Task.WaitAny(tasks);

            Console.WriteLine("ExecuteTime={0}", sw.ElapsedMilliseconds);
        }

        private int GetTheListCount()
        {
            return numList.Count;
        }

        private void AddToList(int num)
        {
            rwls.EnterReadLock();
            if (numList.Count == ENDNUM)
                return;
            rwls.ExitReadLock();

            rwls.EnterWriteLock();
            numList.Add(num);
            rwls.ExitWriteLock();
        }

        private void AddNumToList(object state, CancellationTokenSource cts)
        {
            //Console.WriteLine("This is the {0} thread,Current ThreadId={1}",
            //    state,
            //    Thread.CurrentThread.ManagedThreadId);

            while (!cts.Token.IsCancellationRequested)
            {
                try
                {
                    rwls.EnterReadLock();
                    if (numList.Count == ENDNUM)
                    {
                        cts.Cancel();
                        Console.WriteLine("Current Thread Id={0},Current Count={1}",
                            Thread.CurrentThread.ManagedThreadId,
                            GetTheListCount());
                        break;
                    }
                }
                finally
                {
                    rwls.ExitReadLock();
                }

                var insertNum = GenerateInt32Num();
                if (numList.Contains(insertNum))
                {
                    insertNum = GenerateInt32Num();
                }

                AddToList(insertNum);
            }
        }

        private int GenerateInt32Num()
        {
            return random.Next(1, ENDNUM);
        }
    }
}