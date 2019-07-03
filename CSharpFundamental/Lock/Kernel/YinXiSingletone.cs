using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock
{
    public class YinXiSingletone
    {
        private bool createdNew = false;

        public void SignletoneKernalPattern()
        {
            using (new Semaphore(0, 1, "SomeUniqueStringIdentifyingMyApp", out createdNew))
            {
                if (createdNew)
                {

                }
                else
                {

                }
            }

            using (new EventWaitHandle(createdNew, EventResetMode.AutoReset, "EventWaitHandler"))
            {
                if (true)
                {

                }
            }
        }
    }
}
