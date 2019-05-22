using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class MultipleThreadCompete
    {
        List<int> numList = new List<int>();
        CancellationTokenSource cts = new CancellationTokenSource();
        private const int ENDNUM = 10000;

        internal void DoTheCompeteSecond()
        {
            Task[] tasks = new Task[10];

            for (int i = 0; i < 10; ++i)
            {
                int num = i;
                tasks[i] = Task.Factory.StartNew(() => AddNumToList(num, cts), cts.Token);
            }

            Task.WaitAny(tasks);
        }

        private int GetTheListCount()
        {
            return numList.Count;
        }

        private void AddToList(int num)
        {
            if (numList.Count == ENDNUM)
            {
                return;
            }

            numList.Add(num);
        }

        private void AddNumToList(object state, CancellationTokenSource cts)
        {
            Console.WriteLine("This is the {0} thread,Current ThreadId={1}",
                state,
                Thread.CurrentThread.ManagedThreadId);

            while (!cts.Token.IsCancellationRequested)
            {
                if (GetTheListCount() == ENDNUM)
                {
                    cts.Cancel();
                    Console.WriteLine("Current Thread Id={0},Current Count={1}",
                        Thread.CurrentThread.ManagedThreadId,
                        GetTheListCount());

                    break;
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
            Random random = new Random();

            return random.Next(1, 10000);
        }
    }
}