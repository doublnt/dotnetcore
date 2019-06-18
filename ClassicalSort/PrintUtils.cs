using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalSort
{
    public static class PrintUtils
    {
        public static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
