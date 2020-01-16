using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.Enum
{
    public class EnumTest
    {
        public static void TestEqual()
        {
            Console.WriteLine(3.Equals(MessageType.Pc));
            Console.WriteLine(3.Equals((int)MessageType.Pc));
            Console.WriteLine(MessageType.Pc.Equals(3));
            Console.WriteLine(MessageType.Pc.Equals((MessageType)3));
        }
    }
}
