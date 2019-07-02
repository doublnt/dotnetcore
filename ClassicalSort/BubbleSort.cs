using System;

namespace ClassicalSort
{
    internal class BubbleSort : ISort
    {
        /// <summary>
        ///     比较相邻的元素。如果第一个比第二个大，就交换他们两个。
        ///     对每一对相邻元素作同样的工作，从开始第一对到结尾的最后一对。这步做完后，最后的元素会是最大的数。
        ///     针对所有的元素重复以上的步骤，除了最后一个。
        ///     持续每次对越来越少的元素重复上面的步骤，直到没有任何一对数字需要比较。
        /// </summary>
        private readonly int[] array = { 2, 3423, 535, 1, 223, 543, 636, 2342, 56, 63, 231, 5, 634, 6325 };

        private void RunTheSort(bool ascending = true)
        {
            for (var i = 0; i < array.Length - 1; ++i)
            {
                for (var j = i + 1; j < array.Length; ++j)
                {
                    if (array[j] < array[i])
                    {
                        var change = array[j];
                        array[j] = array[i];
                        array[i] = change;
                    }
                }
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Original Array:");
            PrintUtils.PrintArray(array);
            Console.WriteLine("\n\n\n");

            RunTheSort();

            Console.WriteLine("Bubble Sort:");
            PrintUtils.PrintArray(array);
        }
    }
}
