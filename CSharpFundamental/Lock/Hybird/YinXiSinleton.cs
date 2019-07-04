using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock.Hybird
{
    class YinXiSinleton
    {
        private static YinXiSinleton s_value = new YinXiSinleton();

        private YinXiSinleton()
        {

        }

        public static YinXiSinleton GetSignleton()
        {
            return s_value;
        }
    }

    class YinXiSingleton2
    {
        private static YinXiSingleton2 s_value = null;

        private YinXiSingleton2()
        {

        }

        public static YinXiSingleton2 GetSingleton()
        {
            if (s_value != null)
            {
                return s_value;
            }

            YinXiSingleton2 singleton = new YinXiSingleton2();

            Interlocked.CompareExchange(ref s_value, singleton, null);

            return s_value;
        }
    }
}
