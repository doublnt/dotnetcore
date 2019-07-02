using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    internal class TupleSample
    {
        public static (string, string, int) GetTupleValue()
        {
            var value1 = "test1";
            var value2 = "test2";
            var value3 = 123;

            return (value1, value2, value3);
        }

        public static (string name, string address, uint age) GetStructureTuple()
        {
            var l_name = "Robert";
            var l_address = "China";
            byte a = 1;
            char ch = 'a';
            uint l_age = 24;
            long long1 = 22L;
            double double1 = 30.4;

            return (l_name, l_address, l_age);
        }
    }
}
