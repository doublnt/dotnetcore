using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using CSharpFundamental.AsyncAndAwait;
using CSharpFundamental.Dictionary;
using CSharpFundamental.Enum;
using CSharpFundamental.InteropServiceCom;
using CSharpFundamental.StringMethod;
using CSharpFundamental.ThreadSafe;

namespace CSharpFundamental
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new StopWatch().Run();

            Console.ReadLine();
        }
    }
}
