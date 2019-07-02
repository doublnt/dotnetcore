using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.ILGrammar
{
    internal class ILCodeSample
    {
        public void CalTheILDemo()
        {
            int i = 1;
            int j = 2;
            int k = 3;

            int result = i + k + j;

            Console.WriteLine(i + j + k);
        }
    }
}
