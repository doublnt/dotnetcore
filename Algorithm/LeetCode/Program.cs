using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetTopValue(5, 3) / Factorial(3));
        }

        public static int GetTopValue(int end, int top)
        {
            int sum = 1;
            for (int i = 0; i < top; ++i)
            {
                sum = sum * end;
                end--;
            }
            return sum;
        }

        public static int Factorial(int num)
        {
            if (num == 1)
                return 1;
            return num * Factorial(num - 1);
        }
    }
}
