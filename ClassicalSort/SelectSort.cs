using System;

namespace ClassicalSort
{
    internal class SelectSort :ISort
    {
        /// <summary>
        ///     首先在未排序序列中找到最小（大）元素，存放到排序序列的起始位置
        ///     再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。
        ///     重复第二步，直到所有元素均排序完毕。
        /// </summary>
        private readonly int[] array = { 2, 3423, 535, 1, 223, 543, 636, 2342, 56, 63, 231, 5, 634, 6325 };

        private void ExecuteSelectSort()
        {
            for (var i = 0; i < array.Length - 1; ++i)
            {
                var min = i;

                for (var j = i + 1; j < array.Length; ++j)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                if (i != min)
                {
                    var temp = array[i];
                    array[i] = array[min];
                    array[min] = temp;
                }
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Select Sort:");
            ExecuteSelectSort();

            PrintUtils.PrintArray(array);
        }
    }
}
