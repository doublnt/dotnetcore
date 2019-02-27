using System;

namespace KMPAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = "Code/111";
            var content = "Alibaba/222/Code/222/Code/111";

            new KMP().KMPSearch(pattern, content);
        }
    }
}
