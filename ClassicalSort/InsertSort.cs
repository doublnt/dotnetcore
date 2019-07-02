using System;

namespace ClassicalSort
{
    internal class InsertSort :ISort
    {
        /// <summary>
        ///     将第一待排序序列第一个元素看做一个有序序列，把第二个元素到最后一个元素当成是未排序序列。
        ///     从头到尾依次扫描未排序序列，将扫描到的每个元素插入有序序列的适当位置。
        ///     （如果待插入的元素与有序序列中的某个元素相等，则将待插入元素插入到相等元素的后面。）
        /// </summary>
        private readonly int[] array = { 2, 3423, 535, 1, 223, 543, 636, 2342, 56, 63, 231, 5, 634, 6325 };

        private void RunTheSort()
        {
            for (var i = 0; i < array.Length; ++i)
            {
                var tempValue = array[i];

                for (var j = 0; j < array.Length; ++j)
                {
                    if (array[j] > tempValue)
                    {
                        tempValue = array[j];

                        var change = array[j];
                        array[j] = array[i];
                        array[i] = change;
                    }
                }
            }
        }

        public void PrintArray()
        {
            RunTheSort();

            Console.WriteLine("Insert Sort:");
            PrintUtils.PrintArray(array);
        }
    }
}
