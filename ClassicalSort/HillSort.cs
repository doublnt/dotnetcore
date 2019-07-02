using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalSort
{
    internal class HillSort : ISort
    {
        private readonly int[] array = { 2, 3423, 535, 1, 223, 543, 636, 2342, 56, 63, 231, 5, 634, 6325 };

        private void RunTheSort()
        {
            int gap = 1;

            if (gap < array.Length)
            {
                gap = gap * 4 + 1;
            }

            while (gap > 0)
            {
                for (int i = gap; i < array.Length; ++i)
                {
                    int temp = array[i];

                    int j = i - gap;

                    while (j >= 0 && array[j] > temp)
                    {
                        array[j + gap] = array[j];

                        j -= gap;
                    }

                    array[j + gap] = temp;
                }

                gap = (int)Math.Floor((double)gap / 4);
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Hill Sort:");
            RunTheSort();

            PrintUtils.PrintArray(array);
        }
    }
}
