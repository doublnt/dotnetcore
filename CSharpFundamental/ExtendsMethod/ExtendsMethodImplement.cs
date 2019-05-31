using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.ExtendsMethod
{
    public static class ExtendsMethodImplement
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static T GetValue<T>(this T value) where T : Stream
        {
            return value;
        }
    }
}
