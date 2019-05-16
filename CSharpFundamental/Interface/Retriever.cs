using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.Interface
{
    class Retriever : Dog
    {
        public override Int32 GetFurNum()
        {
            return 300;
        }

//        public override Int64 GetFurNumLong()
//        {
//            return 1000;
//        }
    }
}
