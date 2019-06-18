using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalSort
{
    internal class MergeSort : ISort
    {
        private readonly int[] array = { 2, 3423, 535, 1, 223, 543, 636, 2342, 56, 63, 231, 5, 634, 6325 };

        private int[] Sort()
        {
            if (array.Length < 2)
            {
                return array;
            }

            int middle = (int)Math.Floor((double)array.Length / 2);

            int[] leftArray = new int[middle - 0];
            int[] rightArray = new int[array.Length - middle];

            Array.Copy(array, 0, leftArray, 0, middle);
            Array.Copy(array, middle, rightArray, 0, array.Length - middle);

            return Merge(leftArray, rightArray);
        }

        private int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];

            int i = 0;

            while (left.Length > 0 && right.Length > 0)
            {
                if (left[0] <= right[0])
                {
                    result[i++] = left[0];
                    Array.Copy(left, 1, left, 0, left.Length);
                }
                else
                {
                    result[i++] = right[0];
                    Array.Copy(right, 1, right, 0, right.Length);
                }
            }

            while (left.Length > 0)
            {
                result[i++] = left[0];
                Array.Copy(left, 1, left, 1, left.Length);
            }

            while (right.Length > 0)
            {
                result[i++] = right[0];
                Array.Copy(right, 1, right, 1, right.Length);
            }

            return result;
        }


        public void PrintArray()
        {
            PrintUtils.PrintArray(Sort());
        }
    }
}
