using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class MultipleThreadCompete
    {
        List<int> numList = new List<int>();
        Random random = new Random();
        CancellationTokenSource cts = new CancellationTokenSource();
        private const int TOTAL_NUM = 1000000;
        private const int CURRENT_THREAD_COUNT = 10;

        ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();

        int[] bitMap = new int[TOTAL_NUM];

        //Hashset version
        HashSet<Int32> numListHashSet = new HashSet<int>();

        internal void DoTheCompete()
        {
            //ThreadPool.SetMinThreads(CURRENT_THREAD_COUNT, CURRENT_THREAD_COUNT);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task[] tasks = new Task[CURRENT_THREAD_COUNT];

            for (int i = 0; i < CURRENT_THREAD_COUNT; ++i)
            {
                int num = i;
                //tasks[i] = Task.Run(() => ExecuteTheTaskHashSetVersion(num, cts), cts.Token);
                tasks[i] = Task.Run(() => ExecuteTheTask(num, cts), cts.Token);
            }

            Task.WaitAny(tasks);

            Console.WriteLine("ExecuteTime={0}", sw.ElapsedMilliseconds);
        }

        private void AddToList(int num)
        {
            if (numList.Count == TOTAL_NUM)
                return;
            numList.Add(num);

            var index = num % TOTAL_NUM;
            bitMap[index] = 1;
        }

        private void ExecuteTheTaskHashSetVersion(Object state, CancellationTokenSource cts)
        {
            Console.WriteLine("This is the {0} thread, Current thread Id={1}",
                state,
                Thread.CurrentThread.ManagedThreadId);

            while (!cts.IsCancellationRequested)
            {
                try
                {
                    rwls.EnterReadLock();
                    if (numListHashSet.Count == TOTAL_NUM)
                    {
                        cts.Cancel();

                        Console.WriteLine("Current thread id = {0}, Current Count={1}",
                            Thread.CurrentThread.ManagedThreadId,
                            numListHashSet.Count);

                        break;
                    }
                }
                finally
                {
                    rwls.ExitReadLock();
                }

                int currentNum = GenerateInt32Num();
                rwls.EnterWriteLock();
                var isAdded = numListHashSet.Add(currentNum);
                rwls.ExitWriteLock();

                while (!isAdded)
                {
                    rwls.EnterReadLock();
                    if (numListHashSet.Count == TOTAL_NUM)
                        break;
                    rwls.ExitReadLock();
                    currentNum = GenerateInt32Num();

                    rwls.EnterWriteLock();
                    isAdded = numListHashSet.Add(currentNum);
                    rwls.ExitWriteLock();
                }
            }
        }

        private void ExecuteTheTask(object state, CancellationTokenSource cts)
        {
            Console.WriteLine("This is the {0} thread,Current ThreadId={1}",
                state,
                Thread.CurrentThread.ManagedThreadId);

            while (!cts.IsCancellationRequested)
            {
                try
                {
                    rwls.EnterReadLock();
                    if (numList.Count == TOTAL_NUM)
                    {
                        cts.Cancel();
                        Console.WriteLine("Current Thread Id={0},Current Count={1}",
                            Thread.CurrentThread.ManagedThreadId,
                            numList.Count);
                        break;
                    }
                }
                finally
                {
                    rwls.ExitReadLock();
                }

                var currentNum = GenerateInt32Num();

                while (ContainsNum(currentNum))
                {
                    currentNum = GenerateInt32Num();
                }

                rwls.EnterWriteLock();
                AddToList(currentNum);
                rwls.ExitWriteLock();
            }
        }

        private int GenerateInt32Num()
        {
            var num = random.Next(0, TOTAL_NUM);
            //Console.WriteLine(num);

            return num;
        }

        private bool ContainsNum(int num)
        {
            try
            {
                rwls.EnterReadLock();
                var contains = bitMap[num] == 1;
                return contains;

            }
            finally
            {
                rwls.ExitReadLock();
            }
        }
    }
}