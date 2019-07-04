using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock.Hybird
{
    /// <summary>
    /// 延迟初始化。将对象构造推迟到应用程序首次请求该对象时进行。
    /// </summary>
    class YinXiDoubleCheckLock
    {
        private static object s_lock = new object();

        private static YinXiDoubleCheckLock s_value = null;

        private YinXiDoubleCheckLock()
        {
            // 初始化单例对象代码
            //s_value = new YinXiDoubleCheckLock();
        }

        public static YinXiDoubleCheckLock GetSingleton()
        {
            if (s_value != null)
            {
                return s_value;
            }

            Monitor.Enter(s_lock);

            if (s_value == null)
            {
                YinXiDoubleCheckLock singleton = new YinXiDoubleCheckLock();

                Volatile.Write(ref s_value, singleton);
            }

            Monitor.Exit(s_lock);

            return s_value;
        }
    }
}
