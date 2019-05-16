using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.Interface
{
    class Dog :IAnimialBehaviour
    {
        public virtual Int32 GetFurNum()
        {
            return 10086;
        }

        public Int64 GetFurNumLong()
        {
            return 1003;
        }
    }
}
