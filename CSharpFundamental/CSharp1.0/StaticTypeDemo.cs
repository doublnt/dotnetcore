using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.CSharpVersion1
{
    class StaticTypeDemo
    {
        public void DoStaticTypeThing()
        {
            object o = "string-test";

            Console.WriteLine(((string)o).Length);
        }
    }
}
