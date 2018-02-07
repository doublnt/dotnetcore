using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexMatchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = @"http://q.cnblogs.com/test
q.cnblogs.com/
cnblogs.com/
www.baidu.com/
www.sina.com/
www.google.com/";

            var regex = new Regex(@"(?:[ａ-ｚa-z0-9]{1-50}[.．])?([ａ-ｚa-z0-9]{1,20}[.．][ａ-ｚa-z]{2,4}(?:[.．][ａ-ｚa-z]{2})?)/");
            var matches = regex.Matches(text);
            var domains = matches.Select(m => m.Groups[1].Value);

            var result = domains.GroupBy(x => x)
                .Select(x => new { Domain = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();

            Console.WriteLine($"{result.Domain}, {result.Count}");
        }
    }
}