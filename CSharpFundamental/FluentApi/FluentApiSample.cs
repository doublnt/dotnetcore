using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.FluentApi
{
    public static class FluentApiSample
    {
        public static string Append(this IMarket market)
        {
            var appendValue = "AppendYourself";
    
            Console.WriteLine(market + appendValue);

            return appendValue;
        }
    }

    public interface IMarket
    {
        string GetValue(string args);
    }
}
