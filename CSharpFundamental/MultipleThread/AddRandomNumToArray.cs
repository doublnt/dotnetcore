using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSharpFundamental.MultipleThread
{
    internal class AddRandomNumToArray
    {
        private const int CurrentArraySize = 10000000;
        private const int ThreadCount = 10;
        private static readonly Random random = new Random(DateTime.Now.Millisecond);
        private static volatile int[] randomArray = new int[CurrentArraySize];
        private static volatile int[] finalArray = new int[CurrentArraySize];

        public static void ExecuteTheCode()
        {
            var sw = new Stopwatch();
            sw.Start();

            GenerateRandomIntNumAddToArray();
            OpenMultipleThread();

            Console.WriteLine(sw.ElapsedMilliseconds + "ms");
        }

        private static void GenerateRandomIntNumAddToArray()
        {
            var i = 0;
            var bitArray = new BitArray(CurrentArraySize * 10);

            while (i < CurrentArraySize)
            {
                var num = random.Next(CurrentArraySize * 10);

                if (bitArray.Get(num))
                {
                    continue;
                }

                bitArray.Set(num, true);
                randomArray[i++] = num;
            }
        }

        private static void OpenMultipleThread()
        {
            var tasks = new Task[ThreadCount];
            var splitNum = CurrentArraySize / ThreadCount;

            for (var i = 0; i < ThreadCount; ++i)
            {
                var beginIndex = i * splitNum;
                var endIndex = (i + 1) * splitNum - 1;

                Console.WriteLine(beginIndex + " " + endIndex);
                tasks[i] = Task.Run(() => InsertToFinalArray(beginIndex, endIndex));
            }

            Task.WhenAll(tasks);
        }

        private static void InsertToFinalArray(int beginIndex, int endIndex)
        {
            for (var i = beginIndex; i < endIndex; ++i)
            {
                finalArray[i] = randomArray[i];
            }
        }
    }
}
