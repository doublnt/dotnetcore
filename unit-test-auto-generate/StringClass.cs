using System;

namespace unit_test_auto_generate
{
    public class StringClass
    {
        public string GetComposeValue(string str1, string str2)
        {
            return str1 + str2 + "alibabacloud";
        }

        public int TranscodeToInt(string str1)
        {
            return int.Parse(str1);
        }

        public void GetEnvironmentValue()
        {
            Environment.SetEnvironmentVariable("yinxitest", "yinxitest");
            var value = Environment.GetEnvironmentVariable("yinxitest");
        }
    }
}
