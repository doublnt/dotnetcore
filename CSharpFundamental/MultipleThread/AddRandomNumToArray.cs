﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.MultipleThread
{
    internal class AddRandomNumToArray
    {
        private static readonly Random random = new Random(DateTime.Now.Millisecond);
        private const int CurrentArraySize = 10000000;
        private const int ThreadCount = 20;
        private static volatile int[] randomArray = new int[CurrentArraySize];
        private static volatile int[] finalArray = new int[CurrentArraySize];

        public static void ExecuteTheCode()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            GenerateRandomIntNumAddToArray();
            OpenMultipleThread();

            Console.WriteLine(sw.ElapsedMilliseconds + "ms");

            for (int i = 0; i < 100; i++)
            {
                Console.Write(finalArray[i] + "\t");
            }
        }

        private static void GenerateRandomIntNumAddToArray()
        {
            //int i = 0;
            //var bitArray = new BitArray(CurrentArraySize);

            //while (i < CurrentArraySize)
            //{
            //    var num = random.Next(CurrentArraySize);

            //    if (bitArray.Get(num))
            //    {
            //        continue;
            //    }

            //    bitArray.Set(num, true);
            //    randomArray[i++] = num;
            //}

            for (int i = 0; i < CurrentArraySize; ++i)
            {
                randomArray[i] = i;
            }

            OpenMultipleThreadToShuffle();
        }

        private static void OpenMultipleThread()
        {
            Task[] tasks = new Task[ThreadCount];
            Action[] actions = new Action[ThreadCount];

            int splitNum = CurrentArraySize / ThreadCount;

            for (int i = 0; i < ThreadCount; ++i)
            {
                int beginIndex = i * splitNum;
                int endIndex = (i + 1) * splitNum - 1;

                Console.WriteLine(beginIndex + " " + endIndex);
                tasks[i] = Task.Run(() => InsertToFinalArray(beginIndex, endIndex));
                actions[i] = () => InsertToFinalArray(beginIndex, endIndex);
            }

            //Task.WaitAll(tasks);
            Parallel.Invoke(actions);
        }

        private static void InsertToFinalArray(int beginIndex, int endIndex)
        {
            for (int i = beginIndex; i < endIndex; ++i)
            {
                finalArray[i] = randomArray[i];
            }
        }

        public static void Shuffle<T>(Random rng, T[] array, int beginIndex, int endIndex)
        {
            int n = beginIndex;
            for (int i = n; i < endIndex; ++i)
            {
                int k = rng.Next(CurrentArraySize);

                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        private static void OpenMultipleThreadToShuffle()
        {
            Task[] tasks = new Task[ThreadCount];
            int gap = CurrentArraySize / ThreadCount;

            for (int i = 0; i < ThreadCount; ++i)
            {
                int temp = i;
                tasks[i] = Task.Run(() => Shuffle(random, randomArray, temp * gap, (temp + 1) * gap - 1));
            }

            Task.WaitAll(tasks);
        }
    }
}
