using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace MultipleTaskDemo
{
    class Program
    {
        public static IList<int> testList = new List<int>{3,4};
        static void Main(string[] args)
        {
            bool a = false;
            bool b = false;
            bool c = false;
            Stopwatch watch = new Stopwatch();//测量运行时间
            watch.Start();//开始计时

            //线程1
            Thread threadTest1 = new Thread(() =>
             {
                 Thread.Sleep(2000);
                 AddItem(1);
                 Console.WriteLine("线程1结束消耗时间：{0}", watch.ElapsedMilliseconds);
                 a = true;//如果执行则返回true
             });

            //线程2
            Thread threadTest2 = new Thread(() =>
           {
               Thread.Sleep(2000);
               AddItem(1);
               Console.WriteLine("线程2结束消耗时间：{0}", watch.ElapsedMilliseconds);
               b = true;//如果执行则返回true
           });

            //线程3
            Thread threadTest3 = new Thread(() =>
           {
               Thread.Sleep(2000);
               AddItem(2);
               Console.WriteLine("线程3结束消耗时间：{0}", watch.ElapsedMilliseconds);
               c = true;//如果执行则返回true
           });

            threadTest1.Start();
            threadTest2.Start();
            threadTest3.Start();

            threadTest2.Join();//等待其它线程执行结束
            threadTest1.Join();
            threadTest3.Join();

            if (a == true && b == true && c == true)//当三个子线程全部执行完毕，则执行
            {
                Console.WriteLine("监控结束消耗时间：{0}", watch.ElapsedMilliseconds);
                Console.WriteLine(testList.Count);
                Console.Read();
            }
        }

        static void AddItem(int a)
        {
            if (testList.IndexOf(a) < 0)
            {
                testList.Add(a);
            }
        }
    }
}
