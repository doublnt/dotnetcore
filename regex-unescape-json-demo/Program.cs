using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace regex_unescape_json_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var errorJson = "8\\u000b�@|EX4002 (B1C19) |";
            Console.WriteLine(errorJson);

            var map = new Dictionary<string, string>();
            map.Add("SQLText", "select 'abc\\\"def'");
            map.TryGetValue("SQLText", out string value);
            Console.WriteLine(value);

            var byteValue = System.Text.Encoding.Default.GetBytes(value);
            Console.WriteLine(byteValue);

            var utf8Value = System.Text.Encoding.UTF8.GetString(byteValue);
            Console.WriteLine(utf8Value);

            var regexValue = Regex.Unescape(utf8Value);
            Console.WriteLine(regexValue);
        }
    }
}
