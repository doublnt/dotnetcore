using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CSharpFundamental.StringMethod
{
    public class RegexOptimization
    {
        private const int loops = 100000;
        private static readonly Regex _regex = new Regex(@"^[-_a-zA-Z0-9]{1,150}$", RegexOptions.Compiled);

        private static int[] _intBitMap = new int[123];

        static RegexOptimization()
        {
            Console.WriteLine("Total Count is " + loops);
            InitializeBitMapData();
        }

        public static void Execute()
        {
            Stopwatch sw = Stopwatch.StartNew();

            for (var i = 0; i < loops; i++)
            {
                var str = Guid.NewGuid().ToString();
                _regex.IsMatch(str);
            }

            sw.Stop();
            Console.WriteLine($"First: Elapsed Ticks: {(int)(sw.ElapsedTicks / loops)}");
        }

        private static void InitializeBitMapData()
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                _intBitMap[c] = 1;
            }

            for (char c = 'A'; c <= 'Z'; ++c)
            {
                _intBitMap[c] = 1;
            }

            for (int i = 0; i <= 9; ++i)
            {
                _intBitMap[i] = 1;
            }

            _intBitMap[95] = 1; // _ 95
            _intBitMap[45] = 1; // - 45
        }

        private static bool CalculateBitMap(string value)
        {
            var charValue = value.ToCharArray();
            var count = 0;
            for (int i = 0; i < value.Length; ++i)
            {
                count += _intBitMap[charValue[i]];
            }

            return count >= 1 && count <= 150;
        }

        public static void ExecuteWithOwn()
        {
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < loops; ++i)
            {
                var str = Guid.NewGuid().ToString();

                CalculateBitMap(str);
            }

            sw.Stop();
            Console.WriteLine($"Mine: Elapsed Ticks: {(int)(sw.ElapsedTicks / loops)}");
        }
    }
}
