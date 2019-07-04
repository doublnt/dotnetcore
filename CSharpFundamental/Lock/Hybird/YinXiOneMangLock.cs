using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock.Hybird
{
    internal interface YinXiOneMangLock : IDisposable
    {
        void Dispose();

        void Enter(bool exclusive);
        void Leave();
    }
}
