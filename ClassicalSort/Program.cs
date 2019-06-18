using System;
using System.Collections.Generic;

namespace ClassicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var sortList = new List<ISort>();
            sortList.Add(new BubbleSort());
            sortList.Add(new SelectSort());
            sortList.Add(new InsertSort());
            sortList.Add(new HillSort());
            sortList.Add(new MergeSort());

            foreach (var sort in sortList)
            {
                sort.PrintArray();
            }
        }
    }
}
