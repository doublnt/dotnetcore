using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    internal class Program
    {
        private static Func<string> TestFunc;

        private static List<string> _containerList2 = new List<string>();

        public static void Main(string[] args)
        {
            Task.Run(delegate
            {
                HaveMoneyNeedProductToContinue();
            });

            HaveProductNeedMoneyToContinue();
        }
        public static void HaveProductNeedMoneyToContinue()
        {
            Thread.Sleep(2000);

            lock (_containerList2)
            {
                _containerList2.FirstOrDefault();
            }
        }

        public static void HaveMoneyNeedProductToContinue()
        {
            lock (_containerList2)
            {
                Thread.Sleep(TimeSpan.FromDays(1));
            }

        }

        public static string FormatNumber(long num, int format)
        {
            if (num >= format)
            {
                return (num / format).ToString("0.##M");
            }

            return num.ToString();
        }
    }
}
